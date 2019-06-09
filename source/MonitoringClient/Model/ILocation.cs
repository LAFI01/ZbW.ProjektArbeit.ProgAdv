// ************************************************************************************
// FileName: ILocation.cs
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
  public interface ILocation
  {
    int Fk_Address { get; set; }

    string Building { get; set; }

    int Id { get; set; }

    string Name { get; set; }

    int ParentId { get; set; }
  }
}