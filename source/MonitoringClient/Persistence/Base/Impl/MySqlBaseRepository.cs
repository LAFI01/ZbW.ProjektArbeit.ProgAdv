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
namespace MonitoringClient.Persistence.Base.Impl
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Diagnostics;
  using System.Linq;
  using Base;
  using MySql.Data.MySqlClient;
  using Properties;

  public abstract class MySqlBaseRepository<M> : IRepositoryBase<M>
  {

    protected MySqlBaseRepository()
    {
      MySqlConnection = new MySqlConnection(GetConnectionString());
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

    public M GetSingle<P>(P pkValue)
    {
      throw new NotImplementedException();
    }

    public void Add(M entity)
    {
      throw new NotImplementedException();
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
          for (int i = 0; i < mySqlParameters.Count; i++)
          {
            var p = mySqlParameters[i];
            p.Direction = ParameterDirection.Input;
            p.DbType = dbTypes[i];
            cmd.Parameters.Add(p);
          }
          cmd.ExecuteNonQuery();
        }
      }
    }

    public void Update(M entity)
    {
      throw new NotImplementedException();
    }

    public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    protected abstract M CreateEntity(IDataReader r);

    public List<M> GetAll()
    {
      var allEntries = new List<M>();
      using (IDbConnection conn = MySqlConnection)
      {
        conn.Open();

        var statement = $"select * from {this.TableName}";
          //"select id, pod, location, hostname, severity, timestamp, message from v_logentries order by timestamp";
        using (IDbCommand cmd = CreateCommand(MySqlConnection, CommandType.Text, statement))
        {
          using (IDataReader r = cmd.ExecuteReader())
          {
            while (r.Read())
            {
              var entity = CreateEntity(r);
              allEntries.Add(entity);
            }
          }
        }
      }

      return allEntries;
    }

    public IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    public long Count(string whereCondition, Dictionary<string, object> parameterValues)
    {
      throw new NotImplementedException();
    }

    public long Count()
    {
      throw new NotImplementedException();
    }

    public abstract string TableName { get; }
  }
}