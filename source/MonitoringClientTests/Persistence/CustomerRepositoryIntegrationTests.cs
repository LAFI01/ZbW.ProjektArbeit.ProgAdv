// ************************************************************************************
// FileName: CustomerRepositoryIntegrationTests.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;

  [TestClass]
  public class CustomerRepositoryIntegrationTests
  {
    [TestMethod]
    public void GetAllCustomers_GetAListOfAllCustomers_CheckSuccess()
    {
      ICustomerRepository customerRepo = new CustomerRepository();

      var customers = customerRepo.GetAllCustomer();
    }
  }
}