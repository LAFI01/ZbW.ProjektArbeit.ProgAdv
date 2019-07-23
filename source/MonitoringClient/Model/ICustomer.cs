// ************************************************************************************
// FileName: ICustomer.cs
// Author: 
// Created on: 23.07.2019
// Last modified on: 23.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  public interface ICustomer
  {
    string CustomerNumber { get; set; }

    string Email { get; set; }


    string Firstname { get; set; }


    int Fk_AddressId { get; set; }


    int Id { get; set; }


    string Lastname { get; set; }


    string Password { get; set; }


    string Phone { get; set; }

    string Website { get; set; }
  }
}