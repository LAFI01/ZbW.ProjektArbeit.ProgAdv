// ************************************************************************************
// FileName: Device.cs
// Author: 
// Created on: 06.07.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  using LinqToDB.Mapping;

  [Table("device")]
  public class DeviceDto : DtoBase<int>
  {
    [Column("device_categorie")]
    public string Categorie { get; set; }

    [Column("location_id")]
    public int Fk_LocationId { get; set; }

    [Column("hostname")]
    public string Hostname { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]

    public override int Id { get; set; }

    [Column("ip_address")]

    public string Ip_Address { get; set; }
  }
}