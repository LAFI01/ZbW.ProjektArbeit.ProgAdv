// ************************************************************************************
// FileName: ILogEntry.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;

  public interface ILogEntry
  {
    int DeviceId { get; set; }

    string Hostname { get; set; }

    int Id { get; set; }

    string Location { get; set; }

    string Message { get; set; }

    string Pod { get; set; }

    string Severity { get; set; }

    DateTime Timestamp { get; set; }
  }
}