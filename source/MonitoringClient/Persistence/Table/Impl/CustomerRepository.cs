// ************************************************************************************
// FileName: CustomerRepository.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 14.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table.Impl
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using EntityFramework;
  using Model;
  using Model.Impl;
  using Utilities.Impl;

  public class CustomerRepository : ICustomerRepository
  {
    public void AddCustomer(ICustomer customer)
    {
      customer customerToCreate = CustomerToCustomerDto(customer);
      using (InvDb ctx = new InvDb())
      {
        customer customers = ctx.customers.Add(customerToCreate);
        ctx.SaveChanges();
      }
    }

    public bool DeleteCustomer(ICustomer customer)
    {
      using (InvDb ctx = new InvDb())
      {
        customer customerToDelete = ctx.customers.Find(customer.Id);
        if (customerToDelete != null)
        {
          customer customers = ctx.customers.Remove(customerToDelete);
          var b = ctx.SaveChanges();

          return b > 0;
        }

        throw new ArgumentException("Customer does not exist");
      }
    }

    public List<ICustomer> GetAllCustomer()
    {
      using (InvDb ctx = new InvDb())
      {
        var customersDb = ctx.customers.ToList();
        var customers = customersDb.Select(CustomerDtoToCustomer).ToList();

        return customers;
      }
    }

    public void UpdateCustomer(ICustomer c)
    {
      using (InvDb ctx = new InvDb())
      {
        customer customerToUpdate = ctx.customers.Find(c.Id);
        if (customerToUpdate != null)
        {
          customerToUpdate.kundenNr = c.CustomerNumber;
          customerToUpdate.email = c.Email;
          customerToUpdate.surname = c.Firstname;
          customerToUpdate.name = c.Lastname;
          customerToUpdate.id = c.Id;
          customerToUpdate.password = Encryption.Encrypt(c.Password);
          customerToUpdate.phone = c.Phone;
          customerToUpdate.website = c.Website;
          customerToUpdate.address_id = c.Fk_AddressId;
          ctx.SaveChanges();
        }
      }
    }

    private ICustomer CustomerDtoToCustomer(customer c)
    {
      Customer customerDto = new Customer
      {
        CustomerNumber = c.kundenNr,
        Email = c.email,
        Firstname = c.surname,
        Lastname = c.name,
        Id = c.id,
        Password = Encryption.Decrypt(c.password),
        Phone = c.phone,
        Website = c.website,
        Fk_AddressId = c.address_id
      };

      return customerDto;
    }


    private customer CustomerToCustomerDto(ICustomer c)
    {
      customer customerDto = new customer
      {
        kundenNr = c.CustomerNumber,
        email = c.Email,
        surname = c.Firstname,
        name = c.Lastname,
        id = c.Id,
        password = Encryption.Encrypt(c.Password),
        phone = c.Phone,
        website = c.Website,
        address_id = 2
      };

      return customerDto;
    }
  }
}