// ************************************************************************************
// FileName: MySqlBaseRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 11.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Base.Impl
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Diagnostics;
  using System.Linq;
  using MySql.Data.MySqlClient;
  using Properties;

  public abstract class MySqlBaseRepository<M> : IRepositoryBase<M>
  {
    private MySqlConnection _mySqlConnection;

    protected IDbConnection MySqlConnection
    {
      get
      {
        if (_mySqlConnection == null)
        {
          _mySqlConnection = new MySqlConnection(GetConnectionString());
        }

        return _mySqlConnection;
      }
    }

    public void Add(M entity)
    {
      throw new NotImplementedException();
    }

    public long Count(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    public long Count()
    {
      using (IDbConnection conn = MySqlConnection)
      {
        using (IDbCommand cmd = conn.CreateCommand())
        {
          conn.Open();
          cmd.CommandText = $"select count(*) from {TableName}";

          return (long) cmd.ExecuteScalar();
        }
      }
    }

    public void Delete(M entity)
    {
      throw new NotImplementedException();
    }

    public void ExecuteStoreProcedur(string procedureName, List<MySqlParameter> mySqlParameters, List<DbType> dbTypes)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.StoredProcedure, procedureName))
        {
          for (var i = 0; i < mySqlParameters.Count; i++)
          {
            MySqlParameter p = mySqlParameters[i];
            p.Direction = ParameterDirection.Input;
            p.DbType = dbTypes[i];
            cmd.Parameters.Add(p);
          }

          cmd.ExecuteNonQuery();
        }
      }
    }

    public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
    {
      var allEntries = new List<M>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement = $"select * from {TableName} where {whereCondition}";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              M entity = CreateEntity(r);
              allEntries.Add(entity);
            }
          }
        }
      }
      return allEntries;

    }

    public List<M> GetAll()
    {
      var allEntries = new List<M>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement = $"select * from {TableName}";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              M entity = CreateEntity(r);
              allEntries.Add(entity);
            }
          }
        }
      }

      return allEntries;
    }

    public M GetSingle<P>(P pkValue)
    {
      using (IDbConnection conn = MySqlConnection)
      {
        if (conn.State == ConnectionState.Closed)
        {
          conn.Open();
        }
        var statement = $"select * from {TableName} where id = {pkValue}";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              M entity = CreateEntity(r);

              return entity;
            }
          }
        }
      }

      throw new EntryPointNotFoundException();
    }

    public IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    public abstract string TableName { get; }

    public void Update(M entity)
    {
      throw new NotImplementedException();
    }


    public bool ConnectionTest()
    {
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

    protected abstract M CreateEntity(IDataReader r);

    private string GetConnectionString()
    {
      return Settings.Default.ConnectionString;
    }
  }
}