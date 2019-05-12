// ************************************************************************************
// FileName: MonitoringRepository.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System.Collections.ObjectModel;
  using System.Data;
  using Model;
  using MySql.Data.MySqlClient;

  public class MonitoringRepository : MySqlBaseRepository
  {
    public MonitoringRepository(string connString) : base(connString)
    {
    }

    public void AddLogEntriy(ILogEntry logEntry)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var procedureName = "logMessageAdd";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        {
          MySqlParameter p1 = new MySqlParameter("in_deviceId", logEntry.DeviceId);
          p1.Direction = ParameterDirection.Input;
          p1.DbType = DbType.Int32;
          MySqlParameter p2 = new MySqlParameter("in_hostname", logEntry.Hostname);
          p2.Direction = ParameterDirection.Input;
          p2.DbType = DbType.String;
          MySqlParameter p3 = new MySqlParameter("in_serverity", logEntry.Severity);
          p3.Direction = ParameterDirection.Input;
          p3.DbType = DbType.Int32;
          MySqlParameter p4 = new MySqlParameter("in_message", logEntry.Message);
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

    public void ClearLogEntriy(ILogEntry logEntry)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var procedureName = "LogClear";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        {
          MySqlParameter p1 = new MySqlParameter("id", logEntry.Id);
          p1.Direction = ParameterDirection.Input;
          p1.DbType = DbType.Int32;
          cmd.Parameters.Add(p1);
          cmd.ExecuteNonQuery();
        }
      }
    }

    public ObservableCollection<ILogEntry> GetAllLogEntries()
    {
      var logEntries = new ObservableCollection<ILogEntry>();
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
              ILogEntry logEntry = new LogEntry(r.GetString(3), r.GetString(6), r.GetInt32(4));
              logEntry.Id = r.GetInt32(0);
              logEntry.Pod = r.GetString(1);
              logEntry.Location = r.GetString(2);
              logEntry.Timestamp = r.GetDateTime(5);
              logEntries.Add(logEntry);
            }
          }
        }
      }

      return logEntries;
    }
  }
}