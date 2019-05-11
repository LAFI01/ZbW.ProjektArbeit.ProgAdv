// ************************************************************************************
// FileName: LogEntry.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 11.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Model
{
  using System;
  using System.ComponentModel;
  using System.Reflection;
  using Google.Protobuf.WellKnownTypes;

  internal class LogEntry : ILogEntry
  {
    private string _hostename;

    private int _id;

    private string _location;

    private string _message;

    private string _pod;

    private int _severity;

    private DateTime _timestamp;

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

    public string Pod { get; set; }

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

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}