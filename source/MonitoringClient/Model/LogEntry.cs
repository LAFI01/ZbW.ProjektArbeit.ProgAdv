// ************************************************************************************
// FileName: LogEntry.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;
  using Utilities;

  public class LogEntry : BindableBase, ILogEntry
  {
    private int _deviceId;

    private string _hostename;

    private int _id;

    private string _location;

    private string _message;

    private string _pod;

    private int _severity;

    private DateTime _timestamp;

    public LogEntry(string hostename, string message, int severity)
    {
      Hostname = hostename;
      Message = message;
      Severity = severity;
    }

    public int DeviceId
    {
      get { return _deviceId; }
      set
      {
        _deviceId = value;
        OnPropertyChanged("DeviceId");
      }
    }

    public string Hostname
    {
      get { return _hostename; }
      set
      {
        _hostename = value;

        OnPropertyChanged("Hostname");
      }
    }


    public int Id
    {
      get { return _id; }
      set
      {
        _id = value;
        OnPropertyChanged("Id");
      }
    }

    public string Location
    {
      get { return _location; }
      set
      {
        _location = value;
        OnPropertyChanged("Location");
      }
    }

    public string Message
    {
      get { return _message; }
      set
      {
        _message = value;
        OnPropertyChanged("Message");
      }
    }

    public string Pod
    {
      get { return _pod; }
      set
      {
        _pod = value;
        OnPropertyChanged("Pod");
      }
    }

    public int Severity
    {
      get { return _severity; }
      set
      {
        _severity = value;
        OnPropertyChanged("Severity");
      }
    }

    public DateTime Timestamp
    {
      get { return _timestamp; }
      set
      {
        _timestamp = value;
        OnPropertyChanged("Timestamp");
      }
    }
  }
}