// ************************************************************************************
// FileName: Severity.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 18.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System.Collections.ObjectModel;

  public class Severity
  {
    public static ObservableCollection<string> Severities
    {
      get
      {
        return new ObservableCollection<string>
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