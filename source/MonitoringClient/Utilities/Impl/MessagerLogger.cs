// ************************************************************************************
// FileName: MessagerLogger.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 26.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities.Impl
{
  using System.Collections.Generic;

  public class MessagerLogger : IMessagerLogger
  {
    public MessagerLogger()
    {
      Messages = new List<string>();
    }

    public IList<string> Messages { get; set; }
  }
}