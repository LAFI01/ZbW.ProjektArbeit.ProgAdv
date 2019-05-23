// ************************************************************************************
// FileName: IEntity.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 18.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;

  public interface IEntity
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