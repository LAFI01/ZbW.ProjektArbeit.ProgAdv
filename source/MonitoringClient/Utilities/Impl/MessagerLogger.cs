// ************************************************************************************
// FileName: MessagerLogger.cs
// Author: 
// Created on: 26.07.2019
// Last modified on: 10.08.2019
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
      AddMessages = new List<string>();
    }

    public IList<string> AddMessages { get; set; }

    public string GetMessages()
    {
      var errorMessages = "";
      foreach (var msg in AddMessages)
      {
        errorMessages += string.Concat(msg, ";");
      }

      AddMessages.Clear();

      return errorMessages;
    }
  }
}