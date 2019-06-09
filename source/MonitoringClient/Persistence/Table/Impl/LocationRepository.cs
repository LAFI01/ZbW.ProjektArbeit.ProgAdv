// ************************************************************************************
// FileName: LocationRepository.cs
// Author: 
// Created on: 01.06.2019
// Last modified on: 01.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Data;
  using Base.Impl;
  using Model;
  using Model.Impl;

  public class LocationRepository : MySqlBaseRepository<ILocation>
  {
    protected override ILocation CreateEntity(IDataReader r)
    {
      var entity =
        new Location();
      entity.Id = r.GetInt32(0);
      entity.Name = r.GetString(1);
      entity.Fk_Address = r.GetInt32(2);
      entity.Building = r.GetString(3);
      entity.ParentId = r.GetInt32(4);
      return entity;
    }

    public override string TableName => "Location";

    public List<ILocation> GetAllLocation()
    {
      return GetAll();
    }
  }
}