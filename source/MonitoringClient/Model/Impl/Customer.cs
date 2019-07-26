// ************************************************************************************
// FileName: Customer.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 24.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  using System.Reflection;
  using Prism.Mvvm;

  public class Customer : BindableBase, ICustomer
  {
    private string _customerNumber;

    private string _email;

    private string _firstname;

    private int _id;

    private string _lastname;

    private string _password;

    private string _phone;

    private string _website;


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


    public int Fk_AddressId { get; set; }


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
  }
}