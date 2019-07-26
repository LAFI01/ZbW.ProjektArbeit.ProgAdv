// ************************************************************************************
// FileName: ConstantValue.cs
// Author: 
// Created on: 24.07.2019
// Last modified on: 24.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities.Impl
{
  using System;

  public static class ConstantValue
  {
    private const int LengthOfACustomerNumber = 5;
    public const string PraefixCustomer = "CU";

    public static string GetRandomNumberAsString()
    {
      var random = new Random();
      string numberAsString = random.Next(1, 9).ToString();
      while (numberAsString.Length < LengthOfACustomerNumber)
      {
        numberAsString += random.Next(1, 9).ToString();
      }

      return numberAsString;
    }
  }
}