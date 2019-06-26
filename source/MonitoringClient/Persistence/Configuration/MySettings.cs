// ************************************************************************************
// FileName: MySettings.cs
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
  using System.Collections.Generic;
  using System.Linq;
  using LinqToDB.Configuration;

  public class MySettings : ILinqToDBSettings
  {
    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    {
      get
      {
        yield return
          new ConnectionStringSettings
          {
            Name = "inventarisierungsloesunglfi",
            ProviderName = "MySql",
            ConnectionString = @"Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;pwd=halo1velo;"
          };
      }
    }

    public IEnumerable<IDataProviderSettings> DataProviders
    {
      get { return Enumerable.Empty<IDataProviderSettings>(); }
    }

    public string DefaultConfiguration
    {
      get { return "MySql"; }
    }

    public string DefaultDataProvider
    {
      get { return "MySql"; }
    }
  }
}