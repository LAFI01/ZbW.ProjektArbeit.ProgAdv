// ************************************************************************************
// FileName: MySqlBaseRepository.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 26.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System;
  using System.Data;
  using System.Diagnostics;
  using MySql.Data.MySqlClient;
  using Properties;

  public class MySqlBaseRepository
  {
    protected static IDbConnection MySqlConnection { get; set; }

    public bool ConnectionTest()
    {
      MySqlConnection = new MySqlConnection(GetConnectionString());
      var isConnected = false;
      try
      {
        MySqlConnection.Open();
        isConnected = true;
      }
      catch (Exception ex)
      {
        Debug.Print(string.Format($"Conncetion failed: {ex.Message}"));
      }
      finally
      {
        if (MySqlConnection.State == ConnectionState.Open)
        {
          MySqlConnection.Close();
        }
      }

      return isConnected;
    }

    public void SetConnectionString(string connString)
    {
      Settings.Default.ConnectionString = connString;
    }

    protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
    {
      IDbCommand command = MySqlConnection.CreateCommand();
      command.CommandType = commandType;
      command.CommandText = coomandText;

      return command;
    }

    private string GetConnectionString()
    {
      return Settings.Default.ConnectionString;
    }
  }
}