// ************************************************************************************
// FileName: LocationRepositoryIntegrationTest.cs
// Author: 
// Created on: 22.06.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using System.Linq;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;
  using NUnit.Framework;

  [TestFixture]
  public class LocationRepositoryIntegrationTest
  {
    [Test]
    public void GetAllLocation_GetAllLocations_CheckSuccess()
    {
      ILocationRepository logRepo = new LocationRepository();

      var locationWithChilds = logRepo.GetAllLocation();

      Assert.IsTrue(locationWithChilds.Any());
    }

    [Test]
    public void GetLocationsHierarchical_GetAllLocationWithThereChilds_CheckSuccess()
    {
      ILocationRepository logRepo = new LocationRepository();

      var locationWithChilds = logRepo.GetLocationsHierarchical();

      Assert.IsTrue(locationWithChilds.Any());
    }
  }
}