// ************************************************************************************
// FileName: Location.cs
// Author: 
// Created on: 01.06.2019
// Last modified on: 26.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  using System.Collections.Generic;
  using LinqToDB.Mapping;

  [Table("location")]
  public class Location : ILocation
  {
    public Location()
    {
      Childs = new List<ILocation>();
    }

    [Column("building")]
    public string Building { get; set; }

    public List<ILocation> Childs { get; set; }

    [Column("address_id")]
    public int Fk_Address { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]
    public int Id { get; set; }

    public List<ILocation> Locations { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("parentId")]
    public int ParentId { get; set; }
  }
}