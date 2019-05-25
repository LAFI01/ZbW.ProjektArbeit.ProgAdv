// ************************************************************************************
// FileName: MonitoringRepository.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 18.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Data;
  using Model;
  using MySql.Data.MySqlClient;
  using Properties;
  using Utilities;

  public class MonitoringRepository : MySqlBaseRepository, IMonitoringRepository
  {

    public MonitoringRepository()
    {
    }


    public void AddLogEntriy(IEntity entity)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var procedureName = "logMessageAdd";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        {
          MySqlParameter p1 = new MySqlParameter("in_deviceId", entity.DeviceId);
          p1.Direction = ParameterDirection.Input;
          p1.DbType = DbType.Int32;
          MySqlParameter p2 = new MySqlParameter("in_hostname", entity.Hostname);
          p2.Direction = ParameterDirection.Input;
          p2.DbType = DbType.String;
          MySqlParameter p3 = new MySqlParameter("in_serverity", Mapper.MapSeverityToInt(entity.Severity));
          p3.Direction = ParameterDirection.Input;
          p3.DbType = DbType.Int32;
          MySqlParameter p4 = new MySqlParameter("in_message", entity.Text);
          p4.Direction = ParameterDirection.Input;
          p4.DbType = DbType.String;

          cmd.Parameters.Add(p1);
          cmd.Parameters.Add(p2);
          cmd.Parameters.Add(p3);
          cmd.Parameters.Add(p4);
          cmd.ExecuteNonQuery();
        }
      }
    }

    public void ClearLogEntriy(IEntity entity)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var procedureName = "LogClear";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        {
          MySqlParameter p1 = new MySqlParameter("id", entity.Id);
          p1.Direction = ParameterDirection.Input;
          p1.DbType = DbType.Int32;
          cmd.Parameters.Add(p1);
          cmd.ExecuteNonQuery();
        }
      }
    }

    public List<int> GetAllDeviceIds()
    {
      var deviceIds = new List<int>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement =
          "select  id  from device";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              for (var i = 0; i < r.FieldCount; i++)
              {
                deviceIds.Add(r.GetInt32(i));
              }
            }
          }
        }
      }

      return deviceIds;
    }

    public List<string> GetAllHostname()
    {
      var hostnames = new List<string>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement =
          "select  hostname  from device";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              for (var i = 0; i < r.FieldCount; i++)
              {
                hostnames.Add(r.GetString(i));
              }
            }
          }
        }
      }

      return hostnames;
    }

    public List<IEntity> GetAllLogEntries()
    {
      var logEntries = new List<IEntity>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement =
          "select id, pod, location, hostname, severity, timestamp, message from v_logentries order by timestamp";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              IEntity entity =
                new LogEntry(r.GetString(3), r.GetString(6), Mapper.MapSeverityToString(r.GetInt32(4)));
              entity.Id = r.GetInt32(0);
              entity.Pod = r.GetString(1);
              entity.Location = r.GetString(2);
              entity.Timestamp = r.GetDateTime(5);
              logEntries.Add(entity);
            }
          }
        }
      }

      return logEntries;
    }
  }
}