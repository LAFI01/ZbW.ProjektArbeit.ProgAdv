// ************************************************************************************
// FileName: LogEntry.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 21.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;
  using System.Collections;
  using System.Reflection;
  using Prism.Mvvm;

  public class LogEntry : BindableBase, IEntity
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
      Text = message;
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

    public string Text
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

    public override bool Equals(object value)
    {
      return Equals(value as LogEntry);
    }

    public bool Equals(LogEntry logEntry)
    {
      if (ReferenceEquals(null, logEntry))
      {
        return false;
      }

      if (ReferenceEquals(this, logEntry))
      {
        return true;
      }

      return string.Equals(Severity, logEntry.Severity) && string.Equals(Text, logEntry.Text);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        const int HashingBase = (int) 2166136261;
        const int HashingMultiplier = 16777619;
        var hash = HashingBase;
        hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Severity) ? Severity.GetHashCode() : 0);
        hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, Text) ? Text.GetHashCode() : 0);

        return hash;
      }
    }

    public static bool operator ==(LogEntry logEntryA, LogEntry logEntryB)
    {
      if (ReferenceEquals(logEntryA, logEntryB))
      {
        return true;
      }

      if (ReferenceEquals(null, logEntryA))
      {
        return false;
      }

      return logEntryA.Equals(logEntryB);
    }

    public static bool operator !=(LogEntry logEntryA, LogEntry logEntryB)
    {
      return !(logEntryA == logEntryB);
    }
  }
}