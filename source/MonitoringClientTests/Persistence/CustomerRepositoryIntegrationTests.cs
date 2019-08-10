// ************************************************************************************
// FileName: CustomerRepositoryIntegrationTests.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 10.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClientTests.Persistence
{
  using System;
  using System.Linq;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MonitoringClient.Model;
  using MonitoringClient.Model.Impl;
  using MonitoringClient.Persistence.Table;
  using MonitoringClient.Persistence.Table.Impl;
  using MonitoringClient.Utilities.Impl;

  [TestClass]
  public class CustomerRepositoryIntegrationTests
  {
    [TestMethod]
    public void CRUD_CreateUpdateReadAndDeleteAnUser_CheckSuccess()
    {
      ICustomerRepository customerRepo = new CustomerRepository();

      ICustomer toCreatedCustomer = GetCustomer();
      customerRepo.AddCustomer(toCreatedCustomer);

      ICustomer createdCustomer = GetCustomerByEmail(toCreatedCustomer);

      var expectedWebsite = "www.lafi.ch";
      createdCustomer.Website = expectedWebsite;
      customerRepo.UpdateCustomer(createdCustomer);

      ICustomer updatedCustomer = GetCustomerByEmail(createdCustomer);

      var isDeleted = customerRepo.DeleteCustomer(updatedCustomer);

      ICustomer deletedCustomer = GetCustomerByEmail(updatedCustomer);

      Assert.AreEqual(toCreatedCustomer.Firstname, createdCustomer.Firstname);
      Assert.AreEqual(expectedWebsite, updatedCustomer.Website);
      Assert.IsTrue(isDeleted);
      Assert.IsNull(deletedCustomer);
    }

    [TestMethod]
    public void GetAllCustomers_GetAListOfAllCustomers_CheckSuccess()
    {
      ICustomerRepository customerRepo = new CustomerRepository();

      var customers = customerRepo.GetAllCustomer();

      Assert.IsTrue(customers.Any());
    }

    private ICustomer GetCustomer()
    {
      Customer customer = new Customer
      {
        CustomerNumber = string.Concat(ConstantValue.PraefixCustomer, ConstantValue.GetRandomCustomerNumberAsString()),
        Fk_AddressId = 2,
        Email = string.Concat(DateTime.Now.ToString(), "@time.ch"),
        Firstname = "Pascal",
        Lastname = "Fitze",
        Password = "myPassword1dd23456!"
      };

      return customer;
    }

    private ICustomer GetCustomerByEmail(ICustomer customer)
    {
      ICustomerRepository customerRepo = new CustomerRepository();
      var customers = customerRepo.GetAllCustomer();
      ICustomer searchedCustomer = customers.SingleOrDefault(c => customer.Email.Equals(c.Email));

      return searchedCustomer;
    }
  }
}