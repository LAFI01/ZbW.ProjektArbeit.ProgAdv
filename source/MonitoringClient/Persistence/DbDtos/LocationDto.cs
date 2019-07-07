// ************************************************************************************
// FileName: LocationDto.cs
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

  [Table("location")]
  public class LocationDto : DtoBase<int>
  {
    [Column("building")]
    public string Building { get; set; }


    [Column("address_id")]
    public int Fk_Address { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]
    public override int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("parentId")]
    public int ParentId { get; set; }
  }
}