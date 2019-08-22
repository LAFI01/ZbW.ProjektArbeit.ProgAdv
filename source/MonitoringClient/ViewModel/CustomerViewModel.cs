// ************************************************************************************
// FileName: CustomerViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 22.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System;
  using System.Collections.Generic;
  using System.Reflection;
  using System.Windows;
  using Model;
  using Model.Impl;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using PluginLoader;
  using Prism.Commands;
  using Utilities.Impl;

  public class CustomerViewModel : BindableBase
  {
    private List<ICustomer> _customers;

    private string _fileName;

    private string _filterText;

    private ICustomer _selectedCustomer;

    public CustomerViewModel(ICustomerRepository customerRepository)
    {
      CustomerRepository = customerRepository;
      InitialViewModel();
      MainUserControl = MainUserControlViewModel.GetInstance();
    }

    public DelegateCommand AddCommand { get; set; }

    public DelegateCommand ClearCommand { get; set; }

    public List<ICustomer> Customers
    {
      get { return _customers; }
      set
      {
        SetProperty(ref _customers, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand DeleteCommand { get; set; }

    public string FileName
    {
      get { return _fileName; }
      set
      {
        SetProperty(ref _fileName, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string FilterText
    {
      get { return _filterText; }
      set
      {
        SetProperty(ref _filterText, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand GoBackCommand { get; set; }

    public DelegateCommand SearchCommand { get; set; }

    public ICustomer SelectedCustomer
    {
      get { return _selectedCustomer; }
      set
      {
        SetProperty(ref _selectedCustomer, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand ToCsvCommand { get; set; }

    public DelegateCommand ToJsonCommand { get; set; }

    public DelegateCommand ToTxtCommand { get; set; }

    public DelegateCommand UpdateCommand { get; set; }

    private ICustomerRepository CustomerRepository { get; }

    private List<ICustomer> FilterdCustomerList { get; set; }

    private static CustomerViewModel Instance { get; set; }

    private MainUserControlViewModel MainUserControl { get; }

    public static CustomerViewModel GetInstance()
    {
      if (Instance == null)
      {
        ICustomerRepository customerRepository = new CustomerRepository();
        Instance = new CustomerViewModel(customerRepository);
      }

      return Instance;
    }

    public void LoadCustomers()
    {
      Customers = CustomerRepository.GetAllCustomer();
    }

    public void OnCmdUpdateCustomer()
    {
      CustomerDetailViewModel.GetInstance().LoadRecord(SelectedCustomer);
      NavigateToCustomerDetailView();
    }

    public void RefreshView()
    {
      LoadCustomers();
      RaisCanExecuteChangeHasAnyCustomers();
    }

    private void ExportFile(DataExporter dataExporter)
    {
      try
      {
        var msg = PluginLoader.ExportFile<Customer>(Customers, FileName, dataExporter)
          ? "Export Success"
          : "Export faild";
        MessageBox.Show(msg);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private bool HasAnyCustomers()
    {
      return Customers.Count > 0;
    }

    private bool HasCustomerForFilteredText(ICustomer c)
    {
      var filterText = FilterText.ToUpper();
      var isInFilteredText1 = c.Firstname.ToUpper().Contains(filterText) || c.Lastname.ToUpper().Contains(filterText) ||
                              c.CustomerNumber.ToUpper().Contains(filterText);
      var isInFilteredText2 = !string.IsNullOrEmpty(c.Email) && c.Email.ToUpper().Contains(filterText);
      var isInFilteredText3 = !string.IsNullOrEmpty(c.Phone) && c.Phone.Contains(filterText);
      var isInFilteredText4 = !string.IsNullOrEmpty(c.Password) && c.Password.ToUpper().Contains(filterText);
      var isInFilteredText5 = !string.IsNullOrEmpty(c.Website) && c.Website.ToUpper().Contains(filterText);

      return isInFilteredText1 || isInFilteredText2 || isInFilteredText3 || isInFilteredText4 || isInFilteredText5;
    }

    private void InitialViewModel()
    {
      LoadCustomers();
      FilterdCustomerList = new List<ICustomer>();
      GoBackCommand = new DelegateCommand(OnCmdNavigateToMonitoringView);
      AddCommand = new DelegateCommand(OnCmdAddCustomer);
      UpdateCommand = new DelegateCommand(OnCmdUpdateCustomer, HasAnyCustomers);
      DeleteCommand = new DelegateCommand(OnCmdDeleteCustomer, HasAnyCustomers);
      SearchCommand = new DelegateCommand(OnCmdSearchCustomer);
      ClearCommand = new DelegateCommand(OnCmdClearSearchFilter);
      ToCsvCommand = new DelegateCommand(OnCmdToCsv, HasAnyCustomers);
      ToJsonCommand = new DelegateCommand(OnCmdToJson, HasAnyCustomers);
      ToTxtCommand = new DelegateCommand(OnCmdToTxt, HasAnyCustomers);
    }

    private void NavigateToCustomerDetailView()
    {
      MainUserControl.CustomerDetailVisibility = Visibility.Visible;
      MainUserControl.CustomerVisibility = Visibility.Collapsed;
    }

    private void OnCmdAddCustomer()
    {
      NavigateToCustomerDetailView();
    }

    private void OnCmdClearSearchFilter()
    {
      LoadCustomers();
      FilterText = "";
    }

    private void OnCmdDeleteCustomer()
    {
      var isDeleted = CustomerRepository.DeleteCustomer(SelectedCustomer);
      RefreshView();
      if (!isDeleted)
      {
        MessageBox.Show(ErrorMessage.EntityCouldNotBeDeleted);
      }
    }

    private void OnCmdNavigateToMonitoringView()
    {
      MainUserControl.CustomerVisibility = Visibility.Collapsed;
      MainUserControl.MonitoringVisibility = Visibility.Visible;
    }


    private void OnCmdSearchCustomer()
    {
      LoadCustomers();
      FilterdCustomerList.Clear();
      if (string.IsNullOrEmpty(FilterText))
      {
        MessageBox.Show("Please enter a search text!");
      }
      else
      {
        foreach (ICustomer c in Customers)
        {
          if (HasCustomerForFilteredText(c))
          {
            FilterdCustomerList.Add(c);
          }
        }

        Customers = FilterdCustomerList;
      }
    }

    private void OnCmdToCsv()
    {
      ExportFile(DataExporter.CsvDataExporter);
    }

    private void OnCmdToJson()
    {
      ExportFile(DataExporter.JsonDataExporter);
    }

    private void OnCmdToTxt()
    {
      ExportFile(DataExporter.BinaryDataExporter);
    }

    private void RaisCanExecuteChangeHasAnyCustomers()
    {
      UpdateCommand.RaiseCanExecuteChanged();
      DeleteCommand.RaiseCanExecuteChanged();
      ToCsvCommand.RaiseCanExecuteChanged();
      ToJsonCommand.RaiseCanExecuteChanged();
      ToTxtCommand.RaiseCanExecuteChanged();
    }
  }
}