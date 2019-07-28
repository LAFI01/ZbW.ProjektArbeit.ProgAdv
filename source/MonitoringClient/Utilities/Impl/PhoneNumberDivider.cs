// ************************************************************************************
// FileName: PhoneNumberDivider.cs
// Author: 
// Created on: 27.07.2019
// Last modified on: 28.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities.Impl
{
  using System;
  using System.Text.RegularExpressions;

  public class PhoneNumberDivider
  {
    public PhoneNumberDivider(string phoneNumber)
    {
      DividedPhoneNumberInHerParts(phoneNumber);
    }

    public string AreaCode { get; set; }

    public string CallNumber { get; set; }

    public string DirectDialingIn { get; set; }

    public string InternationAreaCode { get; set; }

    private bool AreNumbersSet(MatchCollection matchCollection, Country county)
    {
      var isNumberSet = false;
      if (matchCollection.Count > 0)
      {
        switch (county)
        {
          case Country.Swiss:
            SetNumberSwiss(matchCollection);
            isNumberSet = true;

            break;
          case Country.Liechtenstein:
            SetNumberLiechtenstein(matchCollection);
            isNumberSet = true;

            break;
        }
      }

      return isNumberSet;
    }

    private void DividedPhoneNumberInHerParts(string phoneNumber)
    {
      var regex = MyRegex.IsValidSwissNumber;
      foreach (Regex r in regex)
      {
        MatchCollection m = r.Matches(phoneNumber);
        if (AreNumbersSet(m, Country.Swiss))
        {
          return;
        }
      }

      Regex germanRegex = MyRegex.IsValidGermanNumber;
      MatchCollection germanMatches = germanRegex.Matches(phoneNumber);
      if (AreNumbersSet(germanMatches, Country.German))
      {
        return;
      }

      Regex liechtensteinRegex = MyRegex.IsValidLiechtensteinNumber;
      MatchCollection liechtensteinMatches = liechtensteinRegex.Matches(phoneNumber);
      if (AreNumbersSet(liechtensteinMatches, Country.Liechtenstein))
      {
        return;
      }

      throw new ArgumentException();
    }


    private void SetNumberLiechtenstein(MatchCollection matches)
    {
      GroupCollection groups = matches[0].Groups;
      var phoneNumber = groups[0].Value;
      InternationAreaCode = groups[1].Value;
      var numberWithoutAreaCodes = MyRegex.IsLiechtensteinAreaCode.Replace(phoneNumber, "");
      CallNumber = numberWithoutAreaCodes.Trim();
    }

    private void SetNumberSwiss(MatchCollection matches)
    {
      GroupCollection groups = matches[0].Groups;
      var phoneNumber = groups[0].Value;

      if (phoneNumber.StartsWith("00") || phoneNumber.StartsWith("+"))
      {
        InternationAreaCode = groups[1].Value;
        AreaCode = groups[2].Value;
        if (!groups[2].Value.Contains("("))
        {
          AreaCode = AreaCode.Insert(0, "0");
        }

        var numberWithoutAreaCodes = MyRegex.IsSwissAreaCode.Replace(phoneNumber, "");
        CallNumber = numberWithoutAreaCodes.Trim();
        if (CallNumber.Contains("-"))
        {
          SplitCallNumberAndDirectialingIn(CallNumber);
        }
      }
      else
      {
        InternationAreaCode = ConstantValue.InternationAreCodeSwiss;
        AreaCode = phoneNumber.Substring(0, 3);
        CallNumber = phoneNumber.Substring(3);
        CallNumber = CallNumber.Trim();
        if (CallNumber.Contains("-"))
        {
          SplitCallNumberAndDirectialingIn(CallNumber);
        }
      }
    }

    private void SplitCallNumberAndDirectialingIn(string callNumberWithDirectDialingIn)
    {
      var splittedByMinus = callNumberWithDirectDialingIn.Split('-');
      CallNumber = splittedByMinus[0];
      DirectDialingIn = splittedByMinus[1];
    }
  }

  public enum Country
  {
    Swiss,

    German,

    Liechtenstein
  }
}