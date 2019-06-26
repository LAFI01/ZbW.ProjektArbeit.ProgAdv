// ************************************************************************************
// FileName: ConnectionStringSettings.cs
// Author: 
// Created on: 26.06.2019
// Last modified on: 26.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Configuration
{
  using LinqToDB.Configuration;

  internal class ConnectionStringSettings : IConnectionStringSettings
  {
    public string ConnectionString { get; set; }

    public bool IsGlobal
    {
      get { return false; }
    }

    public string Name { get; set; }

    public string ProviderName { get; set; }
  }
}