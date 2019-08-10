// ************************************************************************************
// FileName: LogEntryView.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 10.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.View.Impl
{
  using System.Collections.Generic;
  using System.Linq;
  using Base.Impl;
  using DbDtos;
  using Model;
  using Model.Impl;
  using Utilities.Impl;

  public class LogEntryView : MySqlBaseRepository<ViewLogEntryDto, int>, ILogEntryView
  {
    public List<IEntity> GetAllLogEntries()
    {
      var viewLogentries = GetAll();
      var logentries = viewLogentries.Select(e =>
        (IEntity) new LogEntry(e.Hostname, e.Text, Mapper.MapSeverityToString(e.Severity))
        {
          Id = e.Id,
          Pod = e.Pod,
          Location = e.Location,
          Timestamp = e.Timestamp
        }).ToList();

      return logentries;
    }
  }
}