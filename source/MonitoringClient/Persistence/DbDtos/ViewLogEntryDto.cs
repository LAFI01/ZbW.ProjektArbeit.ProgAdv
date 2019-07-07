// ************************************************************************************
// FileName: ViewLogEntryDto.cs
// Author: 
// Created on: 07.07.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  using System;
  using LinqToDB.Mapping;

  [Table("v_logentries")]
  public class ViewLogEntryDto : DtoBase<int>
  {
    [Column("hostname")]
    public string Hostname { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]
    public override int Id { get; set; }

    [Column("location")]
    public string Location { get; set; }

    [Column("pod")]
    public string Pod { get; set; }

    [Column("severity")]
    public int Severity { get; set; }

    [Column("message")]
    public string Text { get; set; }

    [Column("timestamp")]
    public DateTime Timestamp { get; set; }
  }
}