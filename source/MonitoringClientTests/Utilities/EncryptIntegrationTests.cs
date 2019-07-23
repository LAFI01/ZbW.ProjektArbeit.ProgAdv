// ************************************************************************************
// FileName: EncryptIntegrationTests.cs
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
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Utilities;

  [TestClass]
  public class EncryptIntegrationTests
  {
    [TestMethod]
    public void Encrypt_EncryptAnString_CheckSuccess()
    {
      var password = "ichwerdeverschluesselt";

      string encryptedPassword = Encryption.Encrypt(password);

      Assert.AreNotEqual(encryptedPassword, password);
    }

    [TestMethod]
    public void Dencrypt_DencryptAnString_CheckSuccess()
    {
      var password = "ichwerdeverschluesselt";
      var encryptedPassword = Encryption.Encrypt(password);

      var decryptPassword = Encryption.Decrypt(encryptedPassword);

      Assert.AreEqual(decryptPassword, password);
    }
  }
}