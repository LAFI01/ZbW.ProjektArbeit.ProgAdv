// ************************************************************************************
// FileName: ILogEntryView.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
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
    void SetConnectionString(string connString);
    List<IEntity> GetAllLogEntries();

    bool ConnectionTest();
  }
}