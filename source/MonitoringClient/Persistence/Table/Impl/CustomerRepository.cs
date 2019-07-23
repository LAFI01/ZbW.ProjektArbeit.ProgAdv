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
  using System.Collections.Generic;
  using System.Linq;
  using Base.Impl;
  using DbDtos;
  using Model;
  using Model.Impl;

  public class CustomerRepository : MySqlBaseRepository<CustomerDto, int>, ICustomerRepository
  {
    public void AddCustomer(ICustomer customer)
    {
      CustomerDto customerDto = CustomerToCustomerDto(customer);
      Add(customerDto);
    }

    public List<ICustomer> GetAllCustomer()
    {
      var customerDtos = GetAll();
      var customers = customerDtos.Select(c => CustomerDtoToCustomer(c)).ToList();

      return customers;
    }

    public void DeleteCustomer(ICustomer customer)
    {
      CustomerDto customerDto = CustomerToCustomerDto(customer);
      Delete(customerDto);
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
        Password = c.Password,
        Phone = c.Phone,
        Website = c.Website
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
        Password = c.Password,
        Phone = c.Phone,
        Website = c.Website
      };

      return customerDto;
    }
  }
}