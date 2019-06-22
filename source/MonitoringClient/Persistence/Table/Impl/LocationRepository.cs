// ************************************************************************************
// FileName: LocationRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 22.06.2019
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

  public class LocationRepository : MySqlBaseRepository<ILocation>, ILocationRepository
  {
    public override string TableName
    {
      get { return "Location"; }
    }

    public List<ILocation> GetAllLocation()
    {
      return GetAll();
    }

    public List<ILocation> GetLocationsHierarchical()
    {
      var allLocations = GetAll();
      var hirachicalTree = CreateHirachicalTree(allLocations);

      return hirachicalTree;
    }


    protected override ILocation CreateEntity(IDataReader r)
    {
      Location entity =
        new Location();
      entity.Id = r.GetInt32(0);
      entity.Name = r.GetString(1);
      entity.Fk_Address = r.GetInt32(2);
      entity.Building = r.GetString(3);
      entity.ParentId = r.GetInt32(4);

      return entity;
    }

    private List<ILocation> CreateHirachicalTree(List<ILocation> locations)
    {
      var nodes = new List<ILocation>();
      foreach (ILocation item in locations)
      {
        if (item.ParentId == 0)
        {
          nodes.Add(item);
        }
        else
        {
          CreateNode(nodes, item);
        }
      }

      return nodes;
    }

    private void CreateNode(List<ILocation> nodes, ILocation child)
    {
      foreach (ILocation node in nodes)
      {
        if (node.Id == child.ParentId)
        {
          node.Childs.Add(child);
        }
        else
        {
          CreateNode(node.Childs, child);
        }
      }
    }
  }
}