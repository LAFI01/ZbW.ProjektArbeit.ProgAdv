// ************************************************************************************
// FileName: CustomerDto.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.DbDtos
{
  public class CustomerDto : DtoBase<int>
  {
    public override int Id { get; set; }
  }
}