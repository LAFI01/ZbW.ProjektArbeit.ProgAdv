// ************************************************************************************
// FileName: DeviceRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Linq;
  using Base.Impl;
  using DbDtos;
  using Model;
  using Model.Impl;

  public class DeviceRepository : MySqlBaseRepository<DeviceDto, int>, IDeviceRepository
  {
    public List<string> GetDeviceHostname()
    {
      var deviceDtos = GetAll();
      var deviceHostname = deviceDtos.Select(d => d.Hostname).ToList();

      return deviceHostname;
    }

    public List<int> GetDeviceIds()
    {
      var deviceDtos = GetAll();
      var deviceIds = deviceDtos.Select(d => d.Id).ToList();

      return deviceIds;
    }

    public List<IDevice> GetDevices()
    {
      var deviceDtos = GetAll();
      var devices = deviceDtos.Select(d => (IDevice) new Device
      {
        Categorie = d.Categorie,
        Fk_LocationId = d.Fk_LocationId,
        Hostname = d.Hostname,
        Id = d.Id,
        Ip_Address = d.Ip_Address
      }).ToList();

      return devices;
    }
  }
}