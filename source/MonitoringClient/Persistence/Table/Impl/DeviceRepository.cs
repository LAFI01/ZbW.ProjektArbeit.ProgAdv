// ************************************************************************************
// FileName: DeviceRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Data;
  using Base.Impl;
  using Model;
  using Model.Impl;

  public class DeviceRepository : MySqlBaseRepository<IDevice>, IDeviceRepository
  {
    public override string TableName
    {
      get { return "Device"; }
    }

    public List<string> GetDeviceHostname()
    {
      var devices = GetDevices();
      var hostname = new List<string>();
      foreach (IDevice d in devices)
      {
        hostname.Add(d.Hostname);
      }

      return hostname;
    }

    public List<int> GetDeviceIds()
    {
      var devices = GetDevices();
      var ids = new List<int>();
      foreach (IDevice d in devices)
      {
        ids.Add(d.Id);
      }

      return ids;
    }


    public List<IDevice> GetDevices()
    {
      var allDevices = GetAll();

      return allDevices;
    }

    protected override IDevice CreateEntity(IDataReader r)
    {
      Device entity =
        new Device();
      entity.Id = r.GetInt32(0);
      entity.Hostname = r.GetString(1);
      entity.Ip_Address = r.GetString(2);
      entity.Categorie = r.GetString(3);
      entity.Fk_LocationId = r.GetInt32(4);

      return entity;
    }
  }
}