// ************************************************************************************
// FileName: LocationRepositoryIntegrationTests.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using System.Linq;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;

  [TestClass]
  public class LocationRepositoryIntegrationTests
  {
    [TestMethod]
    public void GetAllLocation_GetAllLocations_CheckSuccess()
    {
      ILocationRepository logRepo = new LocationRepository();

      var locationWithChilds = logRepo.GetAllLocation();

      Assert.IsTrue(locationWithChilds.Any());
    }

    [TestMethod]
    public void GetLocationsHierarchical_GetAllLocationWithThereChilds_CheckSuccess()
    {
      ILocationRepository logRepo = new LocationRepository();

      var locationWithChilds = logRepo.GetLocationsHierarchical();

      Assert.IsTrue(locationWithChilds.Any());
    }
  }
}