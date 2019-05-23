// ************************************************************************************
// FileName: MonitoringRepositoryIntegrationTests.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 23.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using MonitoringClient.Model;
  using MonitoringClient.Persistence;
  using NUnit.Framework;

  [TestFixture]
  public class MonitoringRepositoryIntegrationTests
  {
    private const string ConnString = "Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;Pwd=;";

    private IEntity CreateNewLogEntry(int deviceId)
    {
      IEntity entity = new LogEntry("PC1", "Error", "Error");
      entity.DeviceId = deviceId;

      return entity;
    }

    [Test]
    public void AddLogEntry_AddNewLogEntry_LogEntryIsInDbAdded()
    {
      IMonitoringRepository monitoringRepo = new MonitoringRepository();
      monitoringRepo.SetConnectionString(ConnString);
      var logEnriesCountBeforeAdd = monitoringRepo.GetAllLogEntries().Count;

      IEntity newEntity = CreateNewLogEntry(5);
      monitoringRepo.AddLogEntriy(newEntity);

      var logEntriesCountAfterAdd = monitoringRepo.GetAllLogEntries().Count;
      Assert.IsTrue(logEnriesCountBeforeAdd < logEntriesCountAfterAdd);
    }

    [Test]
    public void ClearLogEntriy_QuitOneLogEntry_LogEntriesListShouldBeSamller()
    {
      IMonitoringRepository monitoringRepo = new MonitoringRepository();
      monitoringRepo.SetConnectionString(ConnString);

      IEntity newEntity = CreateNewLogEntry(3);
      monitoringRepo.AddLogEntriy(newEntity);
      var logEnriesAfterAdd = monitoringRepo.GetAllLogEntries();
      var logEnriesCountAfterAdd = logEnriesAfterAdd.Count;

      monitoringRepo.ClearLogEntriy(logEnriesAfterAdd[logEnriesCountAfterAdd - 1]);
      var logEnriesCountAfterClear = monitoringRepo.GetAllLogEntries().Count;

      Assert.IsTrue(logEnriesCountAfterClear < logEnriesCountAfterAdd);
    }

    [Test]
    public void GetAllHostname_LoadAllHostnames_GetAListOfAllHostname()
    {
      IMonitoringRepository monitoringRepo = new MonitoringRepository();
      monitoringRepo.SetConnectionString(ConnString);
      var logEnries = monitoringRepo.GetAllHostname();
      Assert.IsTrue(logEnries.Count > 0);
    }

    [Test]
    public void GetAllLogEntries_LoadAllLogEntries_GetAListOfAllLogEntries()
    {
      IMonitoringRepository monitoringRepo = new MonitoringRepository();
      monitoringRepo.SetConnectionString(ConnString);
      var logEnries = monitoringRepo.GetAllLogEntries();
      Assert.IsTrue(logEnries.Count > 0);
    }
  }
}