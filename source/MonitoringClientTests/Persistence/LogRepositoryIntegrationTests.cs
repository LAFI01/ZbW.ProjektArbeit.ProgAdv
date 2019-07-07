// ************************************************************************************
// FileName: LogRepositoryIntegrationTests.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using MonitoringClient.Model;
  using MonitoringClient.Model.Impl;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;
  using MonitoringClient.Persistence.View;
  using MonitoringClient.Persistence.View.Impl;
  using NUnit.Framework;

  [TestFixture]
  public class LogRepositoryIntegrationTests
  {
    private IEntity CreateNewLogEntry(int deviceId)
    {
      IEntity entity = new LogEntry("PC1", "ErrorMessage", "Error");
      entity.DeviceId = deviceId;

      return entity;
    }

    [Test]
    public void AddLogEntry_AddNewLogEntry_LogEntryIsInDbAdded()
    {
      ILogRepository logRepo = new LogRepository();
      ILogEntryView logView = new LogEntryView();

      var logEnriesCountBeforeAdd = logView.GetAllLogEntries().Count;

      IEntity newEntity = CreateNewLogEntry(4);
      logRepo.AddLogEntry(newEntity);

      var logEntriesCountAfterAdd = logView.GetAllLogEntries().Count;
      Assert.IsTrue(logEnriesCountBeforeAdd < logEntriesCountAfterAdd);
    }

    [Test]
    public void ClearLogEntriy_QuitOneLogEntry_LogEntriesListShouldBeSamller()
    {
      ILogRepository logRepo = new LogRepository();
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

      var deviceEntries = deviceRepo.GetDevices();

      Assert.IsTrue(deviceEntries.Count > 0);
    }

    [Test]
    public void GetAllLogEntries_LoadAllLogEntries_GetAListOfAllLogEntries()
    {
      ILogEntryView logView = new LogEntryView();

      var logEnries = logView.GetAllLogEntries();
      Assert.IsTrue(logEnries.Count > 0);
    }
  }
}