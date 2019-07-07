// ************************************************************************************
// FileName: LogDto.cs
// Author: 
// Created on: 06.07.2019
// Last modified on: 06.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  using System;
  using LinqToDB.Mapping;

  [Table("log")]
  public class LogDto : DtoBase<int>
  {
    [Column("device_id")]
    public int DeviceId { get; set; }

    [Column("hostname")]
    public string Hostname { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]
    public override int Id { get; set; }

    [Column("is_acknowledged")]
    public bool IsAcknowledged { get; set; }

    [Column("serverity")]
    public string Severity { get; set; }

    [Column("message")]
    public string Text { get; set; }

    [Column("time")]
    public DateTime Timestamp { get; set; }
  }
}