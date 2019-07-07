// ************************************************************************************
// FileName: LogRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using Base.Impl;
  using DbDtos;
  using LinqToDB.Data;
  using Model;
  using Utilities;

  public class LogRepository : MySqlBaseRepository<LogDto, int>, ILogRepository
  {
    private const string LogClear = "LogClear";

    private const string LogMessageAdd = "logMessageAdd";

    public void AddLogEntry(IEntity entry)
    {
      var dataParams = new DataParameter[4];
      dataParams[0] = new DataParameter("in_deviceId", entry.DeviceId);
      dataParams[1] = new DataParameter("in_hostname", entry.Hostname);
      dataParams[2] = new DataParameter("in_serverity", Mapper.MapSeverityToInt(entry.Severity));
      dataParams[3] = new DataParameter("in_message", entry.Text);
      ExecuteStoreProcedur(LogMessageAdd, dataParams);
    }


    public void ClearLogEntry(IEntity entry)
    {
      var param = new DataParameter[1] {new DataParameter("id", entry.Id)};
      ExecuteStoreProcedur(LogClear, param);
    }
  }
}