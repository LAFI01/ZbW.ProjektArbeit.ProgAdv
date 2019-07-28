// ************************************************************************************
// FileName: CustomerDetailViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 28.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System;
  using System.Reflection;
  using System.Windows;
  using Model;
  using Model.Impl;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Prism.Commands;
  using Prism.Mvvm;
  using Utilities;
  using Utilities.Impl;
  using Validation;
  using Validation.Impl;

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

    public CustomerDetailViewModel(ICustomerRepository customerRepository, IValidation<ICustomer> customerValidation,
      IMessagerLogger messagerLogger)
    {
      InitialViewModel();
      CustomerRepository = customerRepository;
      CustomerValidation = customerValidation;
      MessagerLogger = messagerLogger;
    }

    public DelegateCommand CancelCommand { get; set; }

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
        PhoneOkCommand.RaiseCanExecuteChanged();
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand PhoneOkCommand { get; set; }

    public DelegateCommand SaveCommand { get; set; }

    public string Website
    {
      get { return _website; }
      set
      {
        SetProperty(ref _website, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private ICustomerRepository CustomerRepository { get; }

    private IValidation<ICustomer> CustomerValidation { get; }

    private static CustomerDetailViewModel Instance { get; set; }

    private IMessagerLogger MessagerLogger { get; }

    public static CustomerDetailViewModel GetInstance()
    {
      if (Instance == null)
      {
        CustomerRepository customerRepository = new CustomerRepository();
        MessagerLogger messageLogger = new MessagerLogger();
        CustomerValidation customerValidation = new CustomerValidation(messageLogger);
        Instance = new CustomerDetailViewModel(customerRepository, customerValidation, messageLogger);
      }

      return Instance;
    }

    public void InitialViewModel()
    {
      CancelCommand = new DelegateCommand(OnCmdNavigateToCustomerView);
      SaveCommand = new DelegateCommand(OnCmdSave);
      PhoneOkCommand = new DelegateCommand(OnCmdTransformPhoneNumber, IsPhoneNumberFieldNotEmpty);
    }

    public void LoadRecord(ICustomer customer)
    {
      CustomerNumber = customer.CustomerNumber;
      Lastname = customer.Lastname;
      Firstname = customer.Firstname;
      Phone = customer.Phone;
      Email = customer.Email;
      Website = customer.Website;
      Password = customer.Password;
    }

    private ICustomer CreateNewCustomer()
    {
      Customer c = new Customer();
      c.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, ConstantValue.GetRandomNumberAsString());
      c.Lastname = Lastname;
      c.Firstname = Firstname;
      c.Email = Email;
      c.Phone = Phone;
      c.Password = Password;
      c.Website = Website;

      return c;
    }

    private bool IsPhoneNumberFieldNotEmpty()
    {
      return Phone?.Length > 0;
    }

    private void OnCmdNavigateToCustomerView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.CustomerVisibility = Visibility.Visible;
      mainUserControl.CustomerDetailVisibility = Visibility.Collapsed;
    }

    private void OnCmdSave()
    {
      ICustomer newCustomer = CreateNewCustomer();
      if (CustomerValidation.DoValidation(newCustomer))
      {
        if (string.IsNullOrEmpty(CustomerNumber))
        {
          CustomerRepository.AddCustomer(newCustomer);
        }
        else
        {
          CustomerRepository.UpdateCustomer(newCustomer);
        }

        CustomerViewModel.GetInstance().RefreshView();
        OnCmdNavigateToCustomerView();
      }
      else
      {
        var errorMessage = MessagerLogger.GetMessages();
        MessageBox.Show(errorMessage);
      }
    }

    private void OnCmdTransformPhoneNumber()
    {
      string msg;
      try
      {
        PhoneNumberTransformer phoneTransformer = new PhoneNumberTransformer(Phone);
        msg = string.Format(
          "International area code: {0} \n Area code: {1}, \n Call number: {2} \n Direct dialing-in: {3}",
          phoneTransformer.InternationAreaCode, phoneTransformer.AreaCode, phoneTransformer.CallNumber,
          phoneTransformer.DirectDialingIn);
      }
      catch (ArgumentException argumentException)
      {
        msg = ErrorMessage.PhoneNumberIsNotValid;
      }

      MessageBox.Show(msg);
    }
  }
}