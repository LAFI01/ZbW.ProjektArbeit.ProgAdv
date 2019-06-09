// ************************************************************************************
// FileName: ILocationRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
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
    void SetConnectionString(string connString);
    List<ILocation> GetAllLocation();
  }
}