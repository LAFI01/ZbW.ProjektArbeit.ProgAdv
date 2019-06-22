// ************************************************************************************
// FileName: LogRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Data;
  using Base.Impl;
  using Model;
  using Model.Impl;
  using MySql.Data.MySqlClient;
  using Utilities;

  public class LogRepository : MySqlBaseRepository<LogEntry>, ILogRepository
  {
    public override string TableName
    {
      get { return "Log"; }
    }

    public void AddLogEntry(IEntity entity)
    {
      var inputKeys = new List<MySqlParameter>
      {
        new MySqlParameter("in_deviceId", entity.DeviceId),
        new MySqlParameter("in_hostname", entity.Hostname),
        new MySqlParameter("in_serverity", Mapper.MapSeverityToInt(entity.Severity)),
        new MySqlParameter("in_message", entity.Text)
      };
      var dbTypes = new List<DbType> {DbType.Int32, DbType.String, DbType.Int32, DbType.String};
      ExecuteStoreProcedur("logMessageAdd", inputKeys, dbTypes);
    }

    public void ClearLogEntry(IEntity entity)
    {
      var inputKeys = new List<MySqlParameter> {new MySqlParameter("id", entity.Id)};

      var dbTypes = new List<DbType> {DbType.Int32};
      ExecuteStoreProcedur("LogClear", inputKeys, dbTypes);
    }

    protected override LogEntry CreateEntity(IDataReader r)
    {
      LogEntry entity =
        new LogEntry(r.GetString(3), r.GetString(6), Mapper.MapSeverityToString(r.GetInt32(4)));
      entity.Id = r.GetInt32(0);
      entity.Pod = r.GetString(1);
      entity.Location = r.GetString(2);
      entity.Timestamp = r.GetDateTime(5);

      return entity;
    }


  }
}