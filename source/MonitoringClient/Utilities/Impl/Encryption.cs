// ************************************************************************************
// FileName: Encryption.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities.Impl
{
  using System;
  using System.IO;
  using System.Security.Cryptography;
  using System.Text;

  public static class Encryption
  {
    private const string StrPermutation = "ouiveyxaqtd";
    private const int BytePermutation1 = 0x19;
    private const int BytePermutation2 = 0x59;
    private const int BytePermutation3 = 0x17;
    private const int BytePermutation4 = 0x41;
    public static string Encrypt(string strData)
    {
      if (strData != null)
      {
        var encoding = Encoding.UTF8.GetBytes(strData);
        var encrypt = Encrypt(encoding);
        return Convert.ToBase64String(encrypt);
      }

      return null;
    }

    public static string Decrypt(string strData)
    {
      if (strData != null)
      {
        var convert = Convert.FromBase64String(strData);
        var decrypt = Decrypt(convert);
        return Encoding.UTF8.GetString(decrypt);
      }
      return null;
    }

    private static byte[] Encrypt(byte[] strData)
    {
      PasswordDeriveBytes passbytes =
      new PasswordDeriveBytes(StrPermutation,
      new byte[] { BytePermutation1,
                         BytePermutation2,
                         BytePermutation3,
                         BytePermutation4
      });

      MemoryStream memstream = new MemoryStream();
      Aes aes = new AesManaged();
      aes.Key = passbytes.GetBytes(aes.KeySize / 8);
      aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

      CryptoStream cryptostream = new CryptoStream(memstream,
      aes.CreateEncryptor(), CryptoStreamMode.Write);
      cryptostream.Write(strData, 0, strData.Length);
      cryptostream.Close();
      return memstream.ToArray();
    }


    private static byte[] Decrypt(byte[] strData)
    {
      PasswordDeriveBytes passbytes =
      new PasswordDeriveBytes(StrPermutation,
      new byte[] { BytePermutation1,
                         BytePermutation2,
                         BytePermutation3,
                         BytePermutation4
      });

      MemoryStream memstream = new MemoryStream();
      Aes aes = new AesManaged();
      aes.Key = passbytes.GetBytes(aes.KeySize / 8);
      aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

      CryptoStream cryptostream = new CryptoStream(memstream,
      aes.CreateDecryptor(), CryptoStreamMode.Write);
      cryptostream.Write(strData, 0, strData.Length);
      cryptostream.Close();
      return memstream.ToArray();
    }
  }
}