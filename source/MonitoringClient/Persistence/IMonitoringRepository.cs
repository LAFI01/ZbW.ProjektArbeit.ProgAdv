// ************************************************************************************
// FileName: IMonitoringRepository.cs
// Author: 
// Created on: 23.05.2019
// Last modified on: 26.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System.Collections.Generic;
  using Model;

  public interface IMonitoringRepository
  {
    void AddLogEntriy(IEntity entity);

    void ClearLogEntriy(IEntity entity);

    bool ConnectionTest();

    List<int> GetAllDeviceIds();

    List<string> GetAllHostname();

    List<IEntity> GetAllLogEntries();

    void SetConnectionString(string connString);
  }
}