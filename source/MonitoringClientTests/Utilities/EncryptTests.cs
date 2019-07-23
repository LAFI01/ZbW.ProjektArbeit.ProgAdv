// ************************************************************************************
// FileName: EncryptTests.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Utilities
{
  using MonitoringClient.Utilities;
  using NUnit.Framework;

  [TestFixture]
  public class EncryptTests
  {
    [Test]
    public void Encrypt_EncryptAnString_CheckSuccess()
    {
      var password = "ichwerdeverschluesselt";

      var encryptedPassword = Encryption.Encrypt(password);

      Assert.AreNotEqual(encryptedPassword, password);
    }
  }
}