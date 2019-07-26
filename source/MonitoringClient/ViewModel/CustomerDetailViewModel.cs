// ************************************************************************************
// FileName: CustomerDetailViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Reflection;
  using System.Windows;
  using Model;
  using Prism.Commands;
  using Prism.Mvvm;

  public class CustomerDetailViewModel : BindableBase
  {
    private string _customerNumber;

    private string _email;

    private string _firstname;

    private int _id;

    private string _lastname;

    private string _password;

    private string _phone;

    private string _website;

    public CustomerDetailViewModel(ICustomer customer)
    {
      InitialViewModel();
      CustomerNumber = customer.CustomerNumber;
      Lastname = customer.Lastname;
      Firstname = customer.Firstname;
      Phone = customer.Phone;
      Email = customer.Phone;
      Website = customer.Website;
      Password = customer.Password;
    }

    public CustomerDetailViewModel()
    {
      InitialViewModel();

    }

    public DelegateCommand CancelCommand { get; set; }
    public DelegateCommand SaveCommand { get; set; }
    public void InitialViewModel()
    {
      CancelCommand = new DelegateCommand(OnCmdNavigateToCustomerView);
      SaveCommand = new DelegateCommand(OnCmdSave, CanSave);
    }

    private bool CanSave()
    {
      return true;
    }


    private void OnCmdSave()
    {
      if (!string.IsNullOrEmpty("gggg"))
      {
     
        CustomerViewModel.GetInstance().RefreshView();
      }
      else
      {
        MessageBox.Show("Please enter a message");
      }
    }
    public string CustomerNumber
    {
      get { return _customerNumber; }
      set
      {
        SetProperty(ref _customerNumber, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Email
    {
      get { return _email; }
      set
      {
        SetProperty(ref _email, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public string Firstname
    {
      get { return _firstname; }
      set
      {
        SetProperty(ref _firstname, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public int Id
    {
      get { return _id; }
      set
      {
        SetProperty(ref _id, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public string Lastname
    {
      get { return _lastname; }
      set
      {
        SetProperty(ref _lastname, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public string Password
    {
      get { return _password; }
      set
      {
        SetProperty(ref _password, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public string Phone
    {
      get { return _phone; }
      set
      {
        SetProperty(ref _phone, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Website
    {
      get { return _website; }
      set
      {
        SetProperty(ref _website, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private static CustomerDetailViewModel Instance { get; set; }

    public static CustomerDetailViewModel GetInstance()
    {
      if (Instance == null)
      {
        //ILocationRepository locationRepo = new LocationRepository();
        Instance = new CustomerDetailViewModel();
      }

      return Instance;
    }

    private void OnCmdNavigateToCustomerView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.CustomerVisibility = Visibility.Visible;
      mainUserControl.CustomerDetailVisibility = Visibility.Collapsed;
    }
  }
}