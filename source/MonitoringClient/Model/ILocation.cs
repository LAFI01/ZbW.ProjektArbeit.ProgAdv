// ************************************************************************************
// FileName: ILocation.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 14.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System.Collections.Generic;

  public interface ILocation
  {
    string Building { get; set; }

    List<ILocation> Childs { get; set; }

    int Fk_Address { get; set; }

    int? Id { get; set; }

    List<ILocation> Locations { get; set; }

    string Name { get; set; }

    int? ParentId { get; set; }
  }
}