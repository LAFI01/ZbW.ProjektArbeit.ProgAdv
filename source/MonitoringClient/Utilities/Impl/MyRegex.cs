// ************************************************************************************
// FileName: MyRegex.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities.Impl
{
  using System.Text.RegularExpressions;

  public static class MyRegex
  {
    public static Regex IsEmailValid = new Regex(@"^[A-Za-z0-9\-_\.]+\@[A-Za-z0-9\._\-]+[A-Za-z]{2,}$");

    public static Regex IsValidCustomerNumber = new Regex(@"^CU[0-9]{5}$");

    //check pattern: [+49 | (+49)] XX XX XX XX XX  |  [+(49) (XXXX) | +49 (XXXX)] XX XX XX
    public static Regex IsValidGermanNumber = new Regex(@"^\(?\+\(?49\)?[ ()]?([- ()]?\d[- ()]?){10}$");

    //check pattern: [+423 | 00423] XXX XX XX
    public static Regex IsValidLiechtensteinNumber = new Regex(@"^(\+423|00423)?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}$");

    //Minimum 8 characters, at least one uppercase letter, one lowercase letter, one number and one special character
    public static Regex IsValidPassword =
      new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

    //Regex 1: [+41 75 | +41 (0)75 | 0041 75 | 0041 (0)75] XXX XX XX
    //Regex 2: Check pattern Regex1 with end -XX
    //Regex 3:: [075 | 075 /] XXX XX XX
    //Regex 4:Check pattern Regex 2 with end -XX
    public static Regex[] IsValidSwissNumber =
    {
      new Regex(@"^(0041|041|\+41|\+\+41)?\s?([0-9]{2}|\(\d\)[0-9]{2})?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}$"),
      new Regex(@"^(0041|041|\+41|\+\+41)?\s?([0-9]{2}|\(\d\)[0-9]{2})?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}\-[0-9]{2}$$"),
      new Regex(@"^[0-9]{3}\s?\/?\s?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}$"),
      new Regex(@"^[0-9]{3}\s?\/?\s?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}\-[0-9]{2}$")
    };

    public static Regex IsWebsiteLinkValid =
      new Regex(@"^((http:\/\/|https:\/\/)?|[w]{3}\.)?[A-Za-z0-9\-_\.]+\.[A-Za-z]+\/?[A-Za-z\?\=\&\!\/\%]+$");
  }
}