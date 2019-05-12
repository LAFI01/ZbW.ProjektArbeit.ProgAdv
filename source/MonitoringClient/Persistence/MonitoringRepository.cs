// ************************************************************************************
// FileName: MonitoringRepository.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 11.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: -
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Data;
  using Model;

  public class MonitoringRepository : MySqlBaseRepository
  {
    public MonitoringRepository(string connString) : base(connString)
    {
      
    }

    public ObservableCollection<ILogEntry> GetAllLogEntries()
    {
      ObservableCollection<ILogEntry> logEntries = new ObservableCollection<ILogEntry>();
      using (var conn = MySqlConnection)
      {
        conn.Open();

        var statement = "select id, pod, location, hostname, severity, timestamp, message from v_logentries order by timestamp";
        using (var cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (var r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              ILogEntry logEntry = new LogEntry(r.GetString(3), r.GetInt32(0), r.GetString(2), r.GetString(6), r.GetString(1),r.GetInt32(4), r.GetDateTime(5));
              logEntries.Add(logEntry);
            }
          }
        }
      }

      return logEntries;
    }
  }
}