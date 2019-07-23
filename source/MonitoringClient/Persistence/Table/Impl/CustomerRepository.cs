// ************************************************************************************
// FileName: CustomerRepository.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using Base.Impl;
  using DbDtos;

  public class CustomerRepository : MySqlBaseRepository<CustomerDto, int>, ICustomerRepository
  {
    public void test()
    {
      
    }
  }
}