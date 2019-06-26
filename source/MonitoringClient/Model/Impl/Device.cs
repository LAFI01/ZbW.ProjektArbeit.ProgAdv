// ************************************************************************************
// FileName: Device.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 26.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  using LinqToDB.Mapping;

  [Table("device")]
  public class Device : IDevice
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

    public int Id { get; set; }

    [Column("ip_address")]

    public string Ip_Address { get; set; }
  }
}