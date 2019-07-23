// ************************************************************************************
// FileName: Customer.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model.Impl
{
  public class Customer : ICustomer
  {
    public string CustomerNumber { get; set; }

    public string Email { get; set; }


    public string Firstname { get; set; }


    public int Fk_AddressId { get; set; }


    public int Id { get; set; }


    public string Lastname { get; set; }


    public string Password { get; set; }


    public string Phone { get; set; }

    public string Website { get; set; }
  }
}