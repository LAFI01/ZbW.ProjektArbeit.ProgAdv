// ************************************************************************************
// FileName: LocationRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 10.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Linq;
  using Base.Impl;
  using DbDtos;
  using Model;
  using Model.Impl;

  public class LocationRepository : MySqlBaseRepository<LocationDto, int>, ILocationRepository
  {
    public List<ILocation> GetAllLocation()
    {
      var locationDtos = GetAll();
      var locations = locationDtos.Select(l => LocationDtoToLocation(l)).ToList();

      return locations;
    }

    public List<ILocation> GetLocationsHierarchical()
    {
      var locations = GetAllLocation();
      var hirachicalTree = CreateHirachicalTree(locations);

      return hirachicalTree;
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

    private ILocation LocationDtoToLocation(LocationDto l)
    {
      Location location = new Location
      {
        Building = l.Building,
        Fk_Address = l.Fk_Address,
        Id = l.Id,
        Name = l.Name,
        ParentId = l.ParentId
      };

      return location;
    }
  }
}