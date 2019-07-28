// ************************************************************************************
// FileName: PhoneNumberDividerTests.cs
// Author: 
// Created on: 27.07.2019
// Last modified on: 28.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Utilities
{
  using System;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Utilities.Impl;

  [TestClass]
  public class PhoneNumberDividerTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DividesPhoneNumberInHerParts__NumberIsInvalid_ThrowException()
    {
      var phoneNumber = "777 888 999 10";
      PhoneNumberDivider p = new PhoneNumberDivider(phoneNumber);

      //Assert is Argument Exception
    }

    [DataTestMethod]
    //swiss number tests
    [DataRow("+41 75 409 00 00", "+41", "075", "409 00 00", null)]
    [DataRow("+41 (0)75 409 00 00-99", "+41", "(0)75", "409 00 00", "99")]
    [DataRow("075 409 00 00", "+41", "075", "409 00 00", null)]
    [DataRow("075 409 00 00-77", "+41", "075", "409 00 00", "77")]
    [DataRow("+41754090000", "+41", "075", "4090000", null)]
    [DataRow("0041 75 409 00 00-99", "0041", "075", "409 00 00", "99")]
    //liechtenstein number tests
    [DataRow("+423 409 00 00", "+423", null, "409 00 00", null)]
    [DataRow("00423 409 00 00", "00423", null, "409 00 00", null)]
    public void DividesPhoneNumberInHerParts_CheckSuccess(string phoneNumber, string expectedInternationalAreaCode,
      string expectedAreaCode, string expectedCallNumber, string expectedDirectDialingIn)


    {
      PhoneNumberDivider p = new PhoneNumberDivider(phoneNumber);

      Assert.AreEqual(expectedInternationalAreaCode, p.InternationAreaCode);
      Assert.AreEqual(expectedAreaCode, p.AreaCode);
      Assert.AreEqual(expectedCallNumber, p.CallNumber);
      Assert.AreEqual(expectedDirectDialingIn, p.DirectDialingIn);
    }
  }
}