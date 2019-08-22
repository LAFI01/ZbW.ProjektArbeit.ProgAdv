// ************************************************************************************
// FileName: PluginLoaderTests.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 22.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.PluginLoader
{
  using System.Collections.Generic;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Model.Impl;
  using MonitoringClient.PluginLoader;
  using MonitoringClient.Utilities.Impl;

  [TestClass]
  public class PluginLoaderTests
  {
    [TestMethod]
    public void ExportFile_TryExportCustomers_CheckSuccess()
    {
      var customer = GetCustomers();
      var fileName = "CustomerTest";

      var isSuccess = PluginLoader.ExportFile<Customer>(customer, fileName, DataExporter.CsvDataExporter);
      Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void ExportFile_TryExportLogEntries_CheckSuccess()
    {
      var logEntries = GetLogEntries();
      var fileName = "LogEntriesTest";
      var isSuccess = PluginLoader.ExportFile<LogEntry>(logEntries, fileName, DataExporter.BinaryDataExporter);
      Assert.IsTrue(isSuccess);
    }

    private List<Customer> GetCustomers()
    {
      var customers = new List<Customer>();
      Customer c = new Customer
      {
        CustomerNumber = ConstantValue.GetRandomCustomerNumberAsString(),
        Email = "lf@gg.ch",
        Firstname = "Testi",
        Lastname = "Tester",
        Fk_AddressId = 2,
        Password = "Passwort!123"
      };
      customers.Add(c);
      customers.Add(c);

      return customers;
    }

    private List<LogEntry> GetLogEntries()
    {
      var logEntries = new List<LogEntry>();
      LogEntry logEntry = new LogEntry("Hostname", "Error", "Low");
      logEntries.Add(logEntry);

      return logEntries;
    }
  }
}