// ************************************************************************************
// FileName: CustomerValidationTests.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Validation
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Model;
  using MonitoringClient.Model.Impl;
  using MonitoringClient.Utilities;
  using MonitoringClient.Utilities.Impl;
  using MonitoringClient.Validation;
  using MonitoringClient.Validation.Impl;

  [TestClass]
  public class CustomerValidationTests
  {
    private IMessagerLogger MessageLogger { get; set; }

    [DataTestMethod]
    [DataRow("CU12345", true)]
    [DataRow("CU123452", false)]
    [DataRow("1CU12345", false)]
    [DataRow("ACU12345", false)]
    [DataRow("CU12A45", false)]
    [DataRow("CU12345B", false)]
    [DataRow("C12A45", false)]
    [DataRow("U12A45", false)]
    [DataRow("AU12A45", false)]
    [DataRow(" AU12A45", false)]
    [DataRow("AU12A45 ", false)]
    public void CustomerValidation_CheckIfCustomerNumberValid_CheckSucess(string customerNumber,
      bool expectedValidation)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = customerNumber;

      var isValid = customerValidation.DoValidation(customer);

      Assert.AreEqual(expectedValidation, isValid);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("lf@gmail.com", true)]
    [DataRow("lf2@lafi02.onmicrosoft.com", true)]
    [DataRow("l-f_2@hotmail.com", true)]
    [DataRow("hallo@gmail_g.ch", true)]
    [DataRow("testü@.c", false)]
    [DataRow("testü@.ch", false)]
    [DataRow("test@gg@.ff.ch", false)]
    [DataRow("mein!mein@gmail.com", false)]
    [DataRow("mein?haha@gmail.com", false)]
    [DataRow("email@güü.ch", false)]
    [DataRow("hallo)@jebla.ch", false)]
    [DataRow("ha lo@jebla.ch", false)]
    [DataRow("hallo@je bla.ch ", false)]
    [DataRow("hallo@jebla.c h", false)]
    [DataRow("hallo@jebla.ch ", false)]
    public void CustomerValidation_CheckIfEmailAddressValid_CheckSucess(string email, bool expectedValidation)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Email = email;

      var isValid = customerValidation.DoValidation(customer);

      Assert.AreEqual(expectedValidation, isValid);
    }

    [DataTestMethod]
    [DataRow("ProgrammingAdvanced2!", true)]
    [DataRow("p1zza!P0", true)]
    [DataRow("alleskleingeschrieben", false)]
    [DataRow("ALLESGROSSGESCHRIEBEN", false)]
    [DataRow("Meine Pizza12!", false)]
    [DataRow("!!!!!!!!!", false)]
    [DataRow("12345678", false)]
    [DataRow("1?Po", false)]
    public void CustomerValidation_CheckIfPasswordValid_CheckSucess(string password, bool expectedValidation)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Password = password;

      var isValid = customerValidation.DoValidation(customer);

      Assert.AreEqual(expectedValidation, isValid);
    }

    [DataTestMethod]
    //swiss number tests
    [DataRow("+41 75 409 00 00", true)]
    [DataRow("+41754090000", true)]
    [DataRow("+41 75 409 00 00-99", true)]
    [DataRow("+41 (0)75 409 00 00", true)]
    [DataRow("0041 75 409 00 00", true)]
    [DataRow("0041 (0)75 409 00 00", true)]
    [DataRow("750 409 00 00", true)]
    [DataRow("750 409 00 00-55", true)]
    [DataRow("7504090000", true)]
    [DataRow("071 / 409 00 00", true)]
    [DataRow("", true)]
    [DataRow("071 409 00 005", false)]
    [DataRow("071 409 00 00-9", false)]
    [DataRow("071 409 00 00-555", false)]
    [DataRow("0071 409 00 00", false)]
    [DataRow("071 4 00 00", false)]
    [DataRow("071 409 4 00", false)]
    [DataRow("071 4098 00 00", false)]
    [DataRow("+888 409 00 00", false)]
    [DataRow("+41 (89)75 409 00 00", false)]
    [DataRow("071 +409 00 00", false)]
    [DataRow("071 [4] 75 409 00 00", false)]
    [DataRow("071 (2 75 409 00 00", false)]
    [DataRow("-41 409 00 00", false)]
    [DataRow("071 409 75 00 00", false)]
    //liechtenstein number tests
    [DataRow("+423 409 00 00", true)]
    [DataRow("00423 409 00 00", true)]
    [DataRow("+423 4029 00 00", false)]
    [DataRow("+00423 409 00 00", false)]
    [DataRow("00423 409 00 009", false)]
    //german number tests
    [DataRow("+491739341284", true)]
    [DataRow("+49 1739341284", true)]
    [DataRow("(+49) 1739341284", true)]
    [DataRow("+49 17 39 34 12 84", true)]
    [DataRow("+49 (1739) 34 12 84", true)]
    [DataRow("+(49) (1739) 34 12 84", true)]
    [DataRow("+49 (1739) 34-12-84", true)]
    [DataRow("+9491739341284", false)]
    [DataRow("++49 1739341284", false)]
    [DataRow("(+49) +1739341284", false)]
    [DataRow("+49 174 39 34 12 84", false)]
    [DataRow("+49 (51739) 34 12 84", false)]
    [DataRow("+(494) (1739) 34 12 84", false)]
    [DataRow("+495 (1739) 34-12-84", false)]
    [DataRow("+(49) (1739) 34 12 84-333", false)]
    [DataRow("+49 (1739) 34-12-84-55", false)]
    public void CustomerValidation_CheckIfPhoneNumberValid_CheckSucess(string phoneNumber, bool expectedValidation)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Phone = phoneNumber;

      var isValid = customerValidation.DoValidation(customer);

      Assert.AreEqual(expectedValidation, isValid);
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow("https://www.google.com", true)]
    [DataRow("http://www.google.com", true)]
    [DataRow("https://www.google.com", true)]
    [DataRow("google.com", true)]
    [DataRow("https://policies.google.com", true)]
    [DataRow("https://policies.google.com/technologies/voice?hl=de&gl=ch%", true)]
    [DataRow("https://www.go ogle.com", false)]
    [DataRow("httpss://www.google.com ", false)]
    [DataRow("https:/www.google.com", false)]
    [DataRow("htt://policies.google.com ", false)]
    [DataRow("https://+policies.google.com  ", false)]
    [DataRow("https:///policies.google.com/technologies/voice?hl=de&gl=ch ", false)]
    public void CustomerValidation_CheckIfWebsiteLinkValid_CheckSucess(string website, bool expectedValidation)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Website = website;

      var isValid = customerValidation.DoValidation(customer);

      Assert.AreEqual(expectedValidation, isValid);
    }


    [DataTestMethod]
    [DataRow("CU12345", "")]
    [DataRow("CU123452", ErrorMessage.CustomerNumberIsNotValid)]
    public void CustomerValidation_CheckIfYouGetTheCorrectErrorMessageForCustomerNumber_CheckSucess(
      string customerNumber, string expectedErrorMessage)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = customerNumber;

      var isValid = customerValidation.DoValidation(customer);

      foreach (var msg in MessageLogger.Messages)
      {
        Assert.AreEqual(expectedErrorMessage, msg);
      }
    }

   
    [DataTestMethod]
    [DataRow("lf@gmail.com", "")]
    [DataRow("hallo@jebla.c h", ErrorMessage.EmailAdressIsNotValid)]
    public void CustomerValidation_CheckIfYouGetTheCorrectErrorMessageForEmailAddress_CheckSucess(string email,
      string expectedErrorMessage)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Email = email;

      var isValid = customerValidation.DoValidation(customer);

      foreach (var msg in MessageLogger.Messages)
      {
        Assert.AreEqual(expectedErrorMessage, msg);
      }
    }

    [DataTestMethod]
    [DataRow("MeinSuperPasswort92?", "")]
    [DataRow("Fgg_", ErrorMessage.PasswordIsNotValid)]
    public void CustomerValidation_CheckIfYouGetTheCorrectErrorMessageForPassword_CheckSucess(
      string password, string expectedErrorMessage)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Password = password;

      var isValid = customerValidation.DoValidation(customer);

      foreach (var msg in MessageLogger.Messages)
      {
        Assert.AreEqual(expectedErrorMessage, msg);
      }
    }

    [DataTestMethod]
    [DataRow("+41 75 409 00 00", "")]
    [DataRow("071 409 75 00 00", ErrorMessage.PhoneNumberIsNotValid)]
    public void CustomerValidation_CheckIfYouGetTheCorrectErrorMessageForPhoneNumber_CheckSucess(string phoneNumber,
      string expectedErrorMessage)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Phone = phoneNumber;

      var isValid = customerValidation.DoValidation(customer);

      foreach (var msg in MessageLogger.Messages)
      {
        Assert.AreEqual(expectedErrorMessage, msg);
      }
    }

    [DataTestMethod]
    [DataRow("https://www.google.com", "")]
    [DataRow("https://www.go ogle.com", ErrorMessage.WebsiteIsNotValid)]
    public void CustomerValidation_CheckIfYouGetTheCorrectErrorMessageForWebsite_CheckSucess(string website,
      string expectedErrorMessage)
    {
      var customerValidation = GetCustomerValidation();
      Customer customer = new Customer();
      customer.CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, "12345");
      customer.Website = website;

      var isValid = customerValidation.DoValidation(customer);

      foreach (var msg in MessageLogger.Messages)
      {
        Assert.AreEqual(expectedErrorMessage, msg);
      }
    }

    private IValidation<ICustomer> GetCustomerValidation()
    {
      MessagerLogger messagerLogger = new MessagerLogger();
      MessageLogger = messagerLogger;

      return new CustomerValidation(MessageLogger);
    }
  }
}