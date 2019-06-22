// ************************************************************************************
// FileName: ILogRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table
{
  using Model;

  public interface ILogRepository 
  {
    void AddLogEntry(IEntity entity);

    void SetConnectionString(string connString);
    void ClearLogEntry(IEntity entity);
  }
}