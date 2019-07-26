// ************************************************************************************
// FileName: CustomerRepository.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using Base.Impl;
  using DbDtos;
  using Model;
  using Model.Impl;
  using MySql.Data.MySqlClient;
  using Utilities;
  using Utilities.Impl;

  public class CustomerRepository : MySqlBaseRepository<CustomerDto, int>, ICustomerRepository
  {
    public void AddCustomer(ICustomer customer)
    {
      CustomerDto customerDto = CustomerToCustomerDto(customer);
      Add(customerDto);
    }

    public bool DeleteCustomer(ICustomer customer)
    {
      CustomerDto customerDto = CustomerToCustomerDto(customer);
      var isDeleted = false;
      try
      {
        Delete(customerDto);
        isDeleted = true;
        
      }
      catch (MySqlException mySqlException)
      {
        Debug.Print(string.Format($"Entity could not be deleted: {mySqlException.Message}"));
      }

      return isDeleted;
    }

    public List<ICustomer> GetAllCustomer()
    {
      var customerDtos = GetAll();
      var customers = customerDtos.Select(c => CustomerDtoToCustomer(c)).ToList();

      return customers;
    }

    public void UpdateCustomer(ICustomer customer)
    {
      CustomerDto customerDto = CustomerToCustomerDto(customer);
      Update(customerDto);
    }

    private ICustomer CustomerDtoToCustomer(CustomerDto c)
    {
      Customer customerDto = new Customer
      {
        CustomerNumber = c.CustomerNumber,
        Email = c.Email,
        Firstname = c.Firstname,
        Lastname = c.Lastname,
        Id = c.Id,
        Password = Encryption.Decrypt(c.Password),
        Phone = c.Phone,
        Website = c.Website,
        Fk_AddressId = c.Fk_AddressId
      };

      return customerDto;
    }


    private CustomerDto CustomerToCustomerDto(ICustomer c)
    {
      CustomerDto customerDto = new CustomerDto
      {
        CustomerNumber = c.CustomerNumber,
        Email = c.Email,
        Firstname = c.Firstname,
        Lastname = c.Lastname,
        Id = c.Id,
        Password = Encryption.Encrypt(c.Password),
        Phone = c.Phone,
        Website = c.Website,
        Fk_AddressId = 2
      };

      return customerDto;
    }
  }
}