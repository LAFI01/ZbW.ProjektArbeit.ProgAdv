﻿// ************************************************************************************
// FileName: CustomerDto.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  using LinqToDB.Mapping;

  [Table("customer")]
  public class CustomerDto : DtoBase<int>
  {
    [Column("kundenNr")]
    public string CustomerNumber { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("surname")]
    public string Firstname { get; set; }

    [Column("address_id")]
    public int Fk_AddressId { get; set; }

    [Column("id")]
    [PrimaryKey]
    [NotNull]
    public override int Id { get; set; }

    [Column("name")]
    public string Lastname { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("phone")]
    public string Phone { get; set; }

    [Column("website")]
    public string Website { get; set; }
  }
}