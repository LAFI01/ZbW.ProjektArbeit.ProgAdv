// ************************************************************************************
// FileName: CustomerValidation.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 28.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Validation.Impl
{
  using System.Text.RegularExpressions;
  using Model;
  using Utilities;
  using Utilities.Impl;

  public class CustomerValidation : IValidation<ICustomer>
  {
    public CustomerValidation(IMessagerLogger messagerLogger)
    {
      MessagerLogger = messagerLogger;
    }

    private IMessagerLogger MessagerLogger { get; }

    public bool DoValidation(ICustomer customer)
    {
      var isValid = true;
      if (!IsCustomerNumberValid(customer.CustomerNumber))
      {
        isValid = false;
        MessagerLogger.AddMessages.Add(ErrorMessage.CustomerNumberIsNotValid);
      }

      if (!IsPhoneNumberValid(customer.Phone))
      {
        isValid = false;
        MessagerLogger.AddMessages.Add(ErrorMessage.PhoneNumberIsNotValid);
      }

      if (!IsEmailValid(customer.Email))
      {
        isValid = false;
        MessagerLogger.AddMessages.Add(ErrorMessage.EmailAdressIsNotValid);
      }

      if (!IsWebsiteLinkValid(customer.Website))
      {
        isValid = false;
        MessagerLogger.AddMessages.Add(ErrorMessage.WebsiteIsNotValid);
      }

      if (!IsPasswordValid(customer.Password))
      {
        isValid = false;
        MessagerLogger.AddMessages.Add(ErrorMessage.PasswordIsNotValid);
      }

      if (IsInputStringTooLong(customer.Lastname, ConstantValue.MaximumFourthyFiveSigns))
      {
        isValid = false;
      }

      if (IsInputStringTooLong(customer.Firstname, ConstantValue.MaximumFourthyFiveSigns))
      {
        isValid = false;
      }

      return isValid;
    }


    private bool IsCustomerNumberValid(string customerNumber)
    {
      Regex regex = MyRegex.IsValidCustomerNumber;

      return !string.IsNullOrEmpty(customerNumber) && regex.IsMatch(customerNumber);
    }

    private bool IsEmailValid(string email)
    {
      //Es wird nicht überprüft, ob es die Domain wirklich gibt und die Route Domain kann ein _ enthalten
      Regex regex = MyRegex.IsEmailValid;

      return !IsInputStringTooLong(email, ConstantValue.MaximumHunderdSigns) &&
             (string.IsNullOrEmpty(email) || regex.IsMatch(email));
    }

    private bool IsGermanNumberValid(string phoneNumber)
    {
      Regex germanRegex = MyRegex.IsValidGermanNumber;
      var isMatch = germanRegex.IsMatch(phoneNumber);

      return isMatch;
    }

    private bool IsInputStringTooLong(string input, int maximumOfSigns)
    {
      if (string.IsNullOrEmpty(input) || input.Length < maximumOfSigns)
      {
        return false;
      }

      MessagerLogger.AddMessages.Add(string.Concat(ErrorMessage.InputStringTooLong, maximumOfSigns));

      return true;
    }

    private bool IsLiechtenSteinNumberValid(string phoneNumber)
    {
      Regex liechtensteinRegex = MyRegex.IsValidLiechtensteinNumber;
      var isMatch = liechtensteinRegex.IsMatch(phoneNumber);

      return isMatch;
    }

    private bool IsPasswordValid(string password)
    {
      return !IsInputStringTooLong(password, ConstantValue.MaximumHunderdSigns) && !string.IsNullOrEmpty(password) &&
             MyRegex.IsValidPassword.IsMatch(password);
    }

    private bool IsPhoneNumberValid(string phoneNumber)
    {
      var isValid = string.IsNullOrEmpty(phoneNumber) ||
                    IsSwissNumberValid(phoneNumber) | IsGermanNumberValid(phoneNumber) ||
                    IsLiechtenSteinNumberValid(phoneNumber);

      return isValid;
    }

    private bool IsSwissNumberValid(string phoneNumber)
    {
      var isMatch = false;
      foreach (Regex regex in MyRegex.IsValidSwissNumber)
      {
        if (regex.IsMatch(phoneNumber))
        {
          isMatch = true;
        }
      }

      return isMatch;
    }

    private bool IsWebsiteLinkValid(string website)
    {
      Regex regex = MyRegex.IsWebsiteLinkValid;

      return !IsInputStringTooLong(website, ConstantValue.MaximumFiveHunderdSigns) &&
             (string.IsNullOrEmpty(website) || regex.IsMatch(website));
    }
  }
}