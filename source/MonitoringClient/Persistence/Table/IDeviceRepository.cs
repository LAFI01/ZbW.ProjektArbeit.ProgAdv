// ************************************************************************************
// FileName: IDeviceRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table
{
  using System.Collections.Generic;
  using Model;

  public interface IDeviceRepository
  {
    List<string> GetDeviceHostname();

    List<int> GetDeviceIds();

    List<IDevice> GetDevices();

  }
}