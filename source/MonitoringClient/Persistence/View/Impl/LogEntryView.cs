// ************************************************************************************
// FileName: LogEntryView.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 11.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.View.Impl
{
  using System.Collections.Generic;
  using System.Data;
  using Base.Impl;
  using Model;
  using Model.Impl;
  using Utilities;

  public class LogEntryView : MySqlBaseRepository<IEntity>, ILogEntryView
  {
    public override string TableName
    {
      get { return "v_logentries"; }
    }


    public List<IEntity> GetAllLogEntries()
    {
      var allLogEntries = GetAll();

      return allLogEntries;
    }


    protected override IEntity CreateEntity(IDataReader r)
    {
      LogEntry entity =
        new LogEntry(r.GetString(3), r.GetString(6), Mapper.MapSeverityToString(r.GetInt32(4)));
      entity.Id = r.GetInt32(0);
      entity.Pod = r.GetString(1);
      entity.Location = r.GetString(2);
      entity.Timestamp = r.GetDateTime(5);

      return entity;
    }
  }
}