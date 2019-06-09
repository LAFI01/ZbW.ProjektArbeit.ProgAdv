// ************************************************************************************
// FileName: Severity.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 26.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  using System.Collections.Generic;

  public class Severity
  {
    public static List<string> Severities
    {
      get
      {
        return new List<string>
        {
          "Error",
          "Warning",
          "Critical",
          "Low"
        };
      }
    }
  }
}