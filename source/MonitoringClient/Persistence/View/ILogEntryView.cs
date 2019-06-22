// ************************************************************************************
// FileName: ILogEntryView.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.View
{
  using System.Collections.Generic;
  using Model;

  public interface ILogEntryView
  {
    bool ConnectionTest();

    List<IEntity> GetAllLogEntries();

    void SetConnectionString(string connString);
  }
}