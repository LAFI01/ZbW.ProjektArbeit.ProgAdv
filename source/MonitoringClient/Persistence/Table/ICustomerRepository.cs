﻿// ************************************************************************************
// FileName: ICustomerRepository.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Table
{
  using System.Collections.Generic;
  using Model;

  public interface ICustomerRepository
  {
    void AddCustomer(ICustomer customer);

    bool DeleteCustomer(ICustomer customer);

    List<ICustomer> GetAllCustomer();

    void UpdateCustomer(ICustomer customer);
  }
}