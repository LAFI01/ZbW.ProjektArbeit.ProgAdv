// ************************************************************************************
// FileName: MySqlBaseRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 22.06.2019
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
  using LinqToDB;
  using LinqToDB.Mapping;
  using Model.Impl;

  public abstract class MySqlBaseRepository<TDto> : LinqToDB.Data.DataConnection, IRepositoryBase<TDto> where TDto : class
  {
    private MySqlConnection _mySqlConnection;

    //public MySqlBaseRepository() : base("inventarisierungsloesunglfi") { }
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

    public void Add(TDto entity)
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

    public void Delete(TDto entity)
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

    public IQueryable<TDto> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
    {
      using (var ctx = new LinqToDB.DataContext("inventarisierungsloesunglfi"))
      {
        var tables = ctx.GetTable<TDto>();

        return tables;

      }

      //var allEntries = new List<TDto>();
      //using (IDbConnection conn = MySqlConnection)
      //{
      //  conn.Open();

      //  var statement = $"select * from {TableName} where {whereCondition}";
      //  using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
      //  {
      //    using (IDataReader r = cmd.ExecuteReader())
      //    {
      //      while (r.Read())
      //      {
      //        TDto entity = CreateEntity(r);
      //        allEntries.Add(entity);
      //      }
      //    }
      //  }
      //}

      //return allEntries;
    }

    public IQueryable<TDto> GetAll()
    {
      using (var ctx = new LinqToDB.DataContext("inventarisierungsloesunglfi"))
      {
        var tables = ctx.GetTable<TDto>();

        return tables;
      //  var allEntries = new List<TDto>();
      //using (IDbConnection conn = MySqlConnection)
      //{
      //  conn.Open();

      //  var statement = $"select * from {TableName}";
      //  using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
      //  {
      //    using (IDataReader r = cmd.ExecuteReader())
      //    {
      //      while (r.Read())
      //      {
      //        TDto entity = CreateEntity(r);
      //        allEntries.Add(entity);
      //      }
      //    }
      //  }
      }

      //return allEntries;
    }

    public TDto GetSingle<P>(P pkValue)
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
              TDto entity = CreateEntity(r);

              return entity;
            }
          }
        }
      }

      throw new EntryPointNotFoundException();
    }

    public IQueryable<TDto> Query(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    public abstract string TableName { get; }

    public void Update(TDto entity)
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

    protected abstract TDto CreateEntity(IDataReader r);

    private string GetConnectionString()
    {
      return Settings.Default.ConnectionString;
    }

    IQueryable<TDto> IRepositoryBase<TDto>.GetAll()
    {
      throw new NotImplementedException();
    }
  }
}