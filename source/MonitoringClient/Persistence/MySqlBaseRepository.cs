﻿// ************************************************************************************
// FileName: MySqlBaseRepository.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 11.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence
{
  using System;
  using System.Data;
  using MySql.Data.MySqlClient;
  using Properties;

  public class MySqlBaseRepository
  {
    protected MySqlBaseRepository()
    {
      MySqlConnection = new MySqlConnection(Settings.Default.ConnectionString);
    }
    protected MySqlBaseRepository(string connString)
    {

      MySqlConnection = new MySqlConnection(connString);
    }
    protected IDbConnection MySqlConnection { get; set; }

   

    protected IDbCommand CreateCommand(IDbConnection myConnection, CommandType commandType, string coomandText)
    {
      IDbCommand command = MySqlConnection.CreateCommand();
      command.CommandType = commandType;
      command.CommandText = coomandText;

      return command;
    }

    protected void DeleteRow(string tablename, string rowName, int value)
    {
      var statement = "DELETE FROM " + tablename + " WHERE " + rowName + " = " + value + ";";
      ExecuteStatemante(statement);
    }

    protected void UpdateRow(string tablename, string rowName, object newValue, int id, string idName)
    {
      var statement = "UPDATE " + tablename + " SET " + rowName + " = " + newValue + " WHERE " + idName + " = " + id +
                      ";";
      ExecuteStatemante(statement);
    }

    private void ExecuteStatemante(string statement)
    {
      try
      {
        MySqlConnection.Open();
        IDbCommand command = CreateCommand(MySqlConnection, CommandType.Text, statement);
        command.ExecuteNonQuery();
      }
      finally
      {
        MySqlConnection.Close();
      }
    }
  }
}