// ************************************************************************************
// FileName: DtoBase.cs
// Author: 
// Created on: 07.07.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  public abstract class DtoBase<TId>
  {
    public abstract TId Id { get; set; }
  }
}