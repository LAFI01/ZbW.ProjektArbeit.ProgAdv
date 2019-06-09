// ************************************************************************************
// FileName: Device.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 09.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  public class Device : IDevice
  {
    public string Categorie { get; set; }

    public int Fk_LocationId { get; set; }

    public string Hostname { get; set; }

    public int Id { get; set; }

    public string Ip_Address { get; set; }
  }
}