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
  using MonitoringClient.Model.Impl;
  using MonitoringClient.Persistence;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;
  using MonitoringClient.Persistence.View;
  using MonitoringClient.Persistence.View.Impl;
  using NUnit.Framework;

  [TestFixture]
  public class MonitoringRepositoryIntegrationTests
  {
    private const string ConnString = "Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;Pwd=halo1velo;";

    private IEntity CreateNewLogEntry(int deviceId)
    {
      IEntity entity = new LogEntry("PC1", "Error", "Error");
      entity.DeviceId = deviceId;

      return entity;
    }

    [Test]
    public void AddLogEntry_AddNewLogEntry_LogEntryIsInDbAdded()
    {
      ILogRepository logRepo = new LogRepository();
      logRepo.SetConnectionString(ConnString);
      ILogEntryView logView = new LogEntryView();

      var logEnriesCountBeforeAdd = logView.GetAllLogEntries().Count;

      IEntity newEntity = CreateNewLogEntry(5);
      logRepo.AddLogEntry(newEntity);

      var logEntriesCountAfterAdd = logView.GetAllLogEntries().Count;
      Assert.IsTrue(logEnriesCountBeforeAdd < logEntriesCountAfterAdd);
    }

    [Test]
    public void ClearLogEntriy_QuitOneLogEntry_LogEntriesListShouldBeSamller()
    {
      ILogRepository logRepo = new LogRepository();
      logRepo.SetConnectionString(ConnString);
      ILogEntryView logView = new LogEntryView();

      IEntity newEntity = CreateNewLogEntry(3);
      logRepo.AddLogEntry(newEntity);
      var logEnriesAfterAdd = logView.GetAllLogEntries();
      var logEnriesCountAfterAdd = logEnriesAfterAdd.Count;

      logRepo.ClearLogEntry(logEnriesAfterAdd[logEnriesCountAfterAdd - 1]);
      var logEnriesCountAfterClear = logView.GetAllLogEntries().Count;

      Assert.IsTrue(logEnriesCountAfterClear < logEnriesCountAfterAdd);
    }

    [Test]
    public void GetAllHostname_LoadAllHostnames_GetAListOfAllHostname()
    {
      IDeviceRepository deviceRepo = new DeviceRepository();
      deviceRepo.SetConnectionString(ConnString);
      var deviceEntries = deviceRepo.GetDevices();
      Assert.IsTrue(deviceEntries.Count > 0);
    }

    [Test]
    public void GetAllLogEntries_LoadAllLogEntries_GetAListOfAllLogEntries()
    {
      ILogEntryView logView = new LogEntryView();
      logView.SetConnectionString(ConnString);

      var logEnries = logView.GetAllLogEntries();
      Assert.IsTrue(logEnries.Count > 0);
    }
  }
}