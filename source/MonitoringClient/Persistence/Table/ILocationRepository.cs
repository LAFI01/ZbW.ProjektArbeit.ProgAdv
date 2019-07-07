// ************************************************************************************
// FileName: ILocationRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 06.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table
{
  using System.Collections.Generic;
  using Model;

  public interface ILocationRepository
  {
    List<ILocation> GetAllLocation();

    List<ILocation> GetLocationsHierarchical();

  }
}