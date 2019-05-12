// ************************************************************************************
// FileName: MonitoringRepositoryIntegrationTests.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using MonitoringClient.Persistence;
  using NUnit.Framework;

  [TestFixture]
  public class MonitoringRepositoryIntegrationTests
  {
    private const string ConnString = "Server=localhost;Database=inventarisierungsloesungv2;Uid=root;Pwd=halo1velo;";

    [Test]
    public void GetAllLogEntries_LoadAllLogEntries_GetAListOfAllLogEntries()
    {
      MonitoringRepository monitoringRepo = new MonitoringRepository(ConnString);
      var logEnries = monitoringRepo.GetAllLogEntries();
      Assert.IsTrue(logEnries.Count > 0);
    }
  }
}