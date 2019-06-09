// ************************************************************************************
// FileName: Location.cs
// Author: 
// Created on: 01.06.2019
// Last modified on: 01.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  public class Location : ILocation
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Fk_Address { get; set; }
    public string Building { get; set; }
    public int ParentId { get; set; }
  }
}