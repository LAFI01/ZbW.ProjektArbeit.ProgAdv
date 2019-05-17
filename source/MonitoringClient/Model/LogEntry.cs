// ************************************************************************************
// FileName: LogEntry.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;
  using System.Reflection;
  using Prism.Mvvm;

  public class LogEntry : BindableBase, ILogEntry
  {
    private int _deviceId;

    private string _hostename;

    private int _id;

    private string _location;

    private string _message;

    private string _pod;

    private string _severity;

    private DateTime _timestamp;

    public LogEntry(string hostename, string message, string severity)
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
        SetProperty(ref _deviceId, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Hostname
    {
      get { return _hostename; }
      set
      {
        SetProperty(ref _hostename, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public int Id
    {
      get { return _id; }
      set
      {
        SetProperty(ref _id, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Location
    {
      get { return _location; }
      set
      {
        SetProperty(ref _location, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Message
    {
      get { return _message; }
      set
      {
        SetProperty(ref _message, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Pod
    {
      get { return _pod; }
      set
      {
        SetProperty(ref _pod, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string Severity
    {
      get { return _severity; }
      set
      {
        SetProperty(ref _severity, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DateTime Timestamp
    {
      get { return _timestamp; }
      set
      {
        SetProperty(ref _timestamp, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }
  }
}