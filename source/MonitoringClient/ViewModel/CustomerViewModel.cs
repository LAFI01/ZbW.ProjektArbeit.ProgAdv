// ************************************************************************************
// FileName: CustomerViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 27.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.Generic;
  using System.Reflection;
  using System.Windows;
  using Model;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Prism.Commands;
  using Prism.Mvvm;
  using Utilities.Impl;

  public class CustomerViewModel : BindableBase
  {
    private List<ICustomer> _customers;

    private ICustomer _selectedCustomer;

    public CustomerViewModel(ICustomerRepository customerRepository)
    {
      CustomerRepository = customerRepository;
      InitialViewModel();
      MainUserControl = MainUserControlViewModel.GetInstance();
    }

    public DelegateCommand AddCommand { get; set; }

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

    public DelegateCommand GoBackCommand { get; set; }

    public ICustomer SelectedCustomer
    {
      get { return _selectedCustomer; }
      set
      {
        SetProperty(ref _selectedCustomer, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand UpdateCommand { get; set; }

    private ICustomerRepository CustomerRepository { get; }

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
      Customers = CustomerRepository.GetAllCustomer();
      UpdateCommand.RaiseCanExecuteChanged();
      DeleteCommand.RaiseCanExecuteChanged();
    }

    private bool HasAnyCustomers()
    {
      return Customers.Count > 0;
    }

    private void InitialViewModel()
    {
      Customers = CustomerRepository.GetAllCustomer();
      GoBackCommand = new DelegateCommand(OnCmdNavigateToMonitoringView);
      AddCommand = new DelegateCommand(OnCmdAddCustomer);
      UpdateCommand = new DelegateCommand(OnCmdUpdateCustomer, HasAnyCustomers);
      DeleteCommand = new DelegateCommand(OnCmdDeleteCustomer, HasAnyCustomers);
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
  }
}