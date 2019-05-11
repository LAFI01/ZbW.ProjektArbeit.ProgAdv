// ************************************************************************************
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

  internal class MySqlBaseRepository
  {
    protected MySqlBaseRepository(string connectionString)
    {
      MySqlConnection = new MySqlConnection(connectionString);
    }

    protected IDbConnection MySqlConnection { get; set; }

    protected bool ConvertToBool(object obj)
    {
      var i = false;
      if (obj is bool)
      {
        i = (bool) obj;
      }

      return i;
    }

    protected DateTime ConvertToDateTime(object obj)
    {
      DateTime date;
      DateTime.TryParse(obj.ToString(), out date);

      return date;
    }

    protected decimal ConvertToDecimal(object obj)
    {
      decimal i = 0;
      if (obj is decimal @decimal)
      {
        i = @decimal;
      }

      return i;
    }

    protected int ConvertToInt(object obj)
    {
      var i = 0;
      if (obj is int)
      {
        i = (int) obj;
      }

      return i;
    }

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