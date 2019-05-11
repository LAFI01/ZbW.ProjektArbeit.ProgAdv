using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.ViewModel
{
  using System.Collections.ObjectModel;
  using System.Collections.Specialized;
  using System.ComponentModel;
  using System.Reflection;
  using System.Runtime.CompilerServices;
  using Model;

  public class MonitoringViewModel : INotifyPropertyChanged, INotifyCollectionChanged
  {
    private static string ConnString { get; set; }

    public ObservableCollection<ILogEntry> _logEntries;

    public ILogEntry _selectedLogEntry;
    
    public MonitoringViewModel(string connString)
    {
      ConnString = connString;
      LogEntries = new ObservableCollection<ILogEntry>();
      //ILogEntry log = new LogEntry() { Hostname = "Test22", Id = 2, Location = "SG", Message = "hallo", Pod = "rr", Severity = 3, Timestamp = new DateTime(2019, 05, 11, 22, 00, 00) };
      //LogEntries.Add(log);

    }

    public ObservableCollection<ILogEntry> LogEntries
    {
      get { return _logEntries; }
      set
      {
        _logEntries = value;
        NotifyPropertyChanged("LogEntries");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
        this.PropertyChanged(this, args);
      }
    }

    public void GetAllLogEntries()
    {
      ILogEntry log = new LogEntry() { Hostname = "Test22", Id = 2, Location = "SG", Message = "hallo", Pod = "rr", Severity = 3, Timestamp = new DateTime(2019, 05, 11, 22, 00, 00) };
      _logEntries.Add(log);
      OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _logEntries));
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      if (CollectionChanged != null)
      {
        CollectionChanged(this, e);
      }
    }
  }
}
