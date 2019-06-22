// ************************************************************************************
// FileName: LocationRepositoryIntegrationTest.cs
// Author: 
// Created on: 22.06.2019
// Last modified on: 22.06.2019
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
    private const string ConnString = "Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;Pwd=halo1velo;";

    [Test]
    public void GetLocationsHierarchical_GetAllLocationWithThereChilds_CheckSuccess()
    {
      ILocationRepository logRepo = new LocationRepository();
      logRepo.SetConnectionString(ConnString);

      var locationWithChilds = logRepo.GetLocationsHierarchical();

      Assert.IsTrue(locationWithChilds.Any());
    }
  }
}