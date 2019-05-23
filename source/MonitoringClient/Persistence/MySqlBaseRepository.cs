// ************************************************************************************
// FileName: MySqlBaseRepository.cs
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
  using System;
  using System.Data;
  using System.Diagnostics;
  using MySql.Data.MySqlClient;
  using Properties;

  public class MySqlBaseRepository 
  {
    protected MySqlBaseRepository()
    {
      
    }

    public string GetConnectionString()
    {
      return Settings.Default.ConnectionString;
    }

    public void SetConnectionString(string connString)
    {
      Settings.Default.ConnectionString = connString;
    }

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
        Debug.Print("Conncetion failed");
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

    protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
    {
      IDbCommand command = MySqlConnection.CreateCommand();
      command.CommandType = commandType;
      command.CommandText = coomandText;

      return command;
    }
  }
}