// ************************************************************************************
// FileName: IDevice.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  public interface IDevice
  {
    string Categorie { get; set; }

    int Fk_LocationId { get; set; }

    string Hostname { get; set; }

    int Id { get; set; }

    string Ip_Address { get; set; }
  }
}