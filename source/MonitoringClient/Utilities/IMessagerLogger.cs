// ************************************************************************************
// FileName: IMessagerLogger.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities
{
  using System.Collections.Generic;

  public interface IMessagerLogger
  {
    IList<string> Messages { get; set; }
  }
}