using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClientTests.Persistence
{
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
