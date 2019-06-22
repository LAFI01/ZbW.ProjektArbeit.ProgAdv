// ************************************************************************************
// FileName: Location.cs
// Author: 
// Created on: 01.06.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  using System.Collections.Generic;

  public class Location : ILocation
  {
    public Location()
    {
      Childs = new List<ILocation>();
    }

    public string Building { get; set; }

    public List<ILocation> Childs { get; set; }

    public int Fk_Address { get; set; }

    public int Id { get; set; }

    public List<ILocation> Locations { get; set; }

    public string Name { get; set; }

    public int ParentId { get; set; }
  }
}