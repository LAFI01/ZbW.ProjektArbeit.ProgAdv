// ************************************************************************************
// FileName: LocationRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 14.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Linq;
  using EntityFramework;
  using Model;
  using Model.Impl;

  public class LocationRepository : ILocationRepository
  {
    public List<ILocation> GetAllLocation()
    {
      var locations = new List<ILocation>();
      using (InvDb ctx = new InvDb())
      {
        var locationWithPods = ctx.view_locationWithPodV5.ToList();
        locations = locationWithPods.Select(l => LocationDtoToLocation(l)).ToList();
      }

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

    private ILocation LocationDtoToLocation(view_locationWithPodV5 l)
    {
      Location location = new Location
      {
        Building = l.building,
        Id = l.locationId,
        Name = l.locationName,
        ParentId = l.parentId
      };

      return location;
    }
  }
}