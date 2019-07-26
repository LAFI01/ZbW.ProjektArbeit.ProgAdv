// ************************************************************************************
// FileName: CustomerViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 22.07.2019
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

  public class CustomerViewModel : BindableBase
  {
    private static CustomerViewModel Instance { get; set; }
    private ICustomer _selectedCustomer;
    private List<ICustomer> _customers;
    private ICustomerRepository CustomerRepository { get; set; }

    public CustomerViewModel(ICustomerRepository customerRepository)
    {
      CustomerRepository = customerRepository;
      InitialViewModel();
      MainUserControl = MainUserControlViewModel.GetInstance();
    }

    private MainUserControlViewModel MainUserControl { get; set; }
    public DelegateCommand AddCommand { get; set; }

    public DelegateCommand UpdateCommand { get; set; }

    public DelegateCommand DeleteCommand { get; set; }

    public DelegateCommand GoBackCommand { get; set; }

    private void InitialViewModel()
    {
      Customers = CustomerRepository.GetAllCustomer();
      GoBackCommand = new DelegateCommand(OnCmdNavigateToMonitoringView);
      AddCommand = new DelegateCommand(OnCmdNavigateToCustomerDetailView);
      UpdateCommand = new DelegateCommand(OnCmdNavigateToCustomerDetailView, HasAnyCustomers);
      DeleteCommand = new DelegateCommand(OnCmdDeleteCustomer, HasAnyCustomers);

    }

    private void OnCmdDeleteCustomer()
    {
      var isDeleted = CustomerRepository.DeleteCustomer(SelectedCustomer);
      RefreshView();
      if (!isDeleted)
      {
        MessageBox.Show("Entity could not be deleted");
      }
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

    private void OnCmdNavigateToCustomerDetailView()
    {
      MainUserControl.CustomerDetailVisibility = Visibility.Visible;
      MainUserControl.CustomerVisibility = Visibility.Collapsed;
    }

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

    public List<ICustomer> Customers
    {
      get { return _customers; }
      set
      {
        SetProperty(ref _customers, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public ICustomer SelectedCustomer
    {
      get { return _selectedCustomer; }
      set
      {
        SetProperty(ref _selectedCustomer, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private void OnCmdNavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.CustomerVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }
  }
}