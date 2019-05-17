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
  using MonitoringClient.Model;
  using MonitoringClient.Persistence;
  using NUnit.Framework;

  [TestFixture]
  public class MonitoringRepositoryIntegrationTests
  {
    private const string ConnString = "Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;Pwd=halo1velo;";

    private ILogEntry CreateNewLogEntry(int deviceId)
    {
      ILogEntry logEntry = new LogEntry("PC1", "Error", "Error");
      logEntry.DeviceId = deviceId;

      return logEntry;
    }

    [Test]
    public void AddLogEntry_AddNewLogEntry_LogEntryIsInDbAdded()
    {
      MonitoringRepository monitoringRepo = new MonitoringRepository(ConnString);
      var logEnriesCountBeforeAdd = monitoringRepo.GetAllLogEntries().Count;

      ILogEntry newLogEntry = CreateNewLogEntry(5);
      monitoringRepo.AddLogEntriy(newLogEntry);

      var logEntriesCountAfterAdd = monitoringRepo.GetAllLogEntries().Count;
      Assert.IsTrue(logEnriesCountBeforeAdd < logEntriesCountAfterAdd);
    }

    [Test]
    public void ClearLogEntriy_QuitOneLogEntry_LogEntriesListShouldBeSamller()
    {
      MonitoringRepository monitoringRepo = new MonitoringRepository(ConnString);

      ILogEntry newLogEntry = CreateNewLogEntry(3);
      monitoringRepo.AddLogEntriy(newLogEntry);
      var logEnriesAfterAdd = monitoringRepo.GetAllLogEntries();
      var logEnriesCountAfterAdd = logEnriesAfterAdd.Count;

      monitoringRepo.ClearLogEntriy(logEnriesAfterAdd[logEnriesCountAfterAdd - 1]);
      var logEnriesCountAfterClear = monitoringRepo.GetAllLogEntries().Count;

      Assert.IsTrue(logEnriesCountAfterClear < logEnriesCountAfterAdd);
    }

    [Test]
    public void GetAllLogEntries_LoadAllLogEntries_GetAListOfAllLogEntries()
    {
      MonitoringRepository monitoringRepo = new MonitoringRepository(ConnString);
      var logEnries = monitoringRepo.GetAllLogEntries();
      Assert.IsTrue(logEnries.Count > 0);
    }

    [Test]
    public void GetAllHostname_LoadAllHostnames_GetAListOfAllHostname()
    {
      MonitoringRepository monitoringRepo = new MonitoringRepository(ConnString);
      var logEnries = monitoringRepo.GetAllHostname();
      Assert.IsTrue(logEnries.Count > 0);
    }
  }
}