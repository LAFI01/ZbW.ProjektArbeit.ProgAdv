// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.ObjectModel;
  using System.Collections.Specialized;
  using Model;
  using Persistence;
  using Utilities;

  public class MonitoringViewModel : ChangeBase
  {
    public ObservableCollection<ILogEntry> _logEntries;

    public ILogEntry _selectedLogEntry;

    public MonitoringViewModel(string connString)
    {
      LogEntries = new ObservableCollection<ILogEntry>();
      MonitoringRepository = new MonitoringRepository(connString);
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

    private MonitoringRepository MonitoringRepository { get; }


    public void GetAllLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
      foreach (ILogEntry log in LogEntries)
      {
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, log));
      }
    }
  }
}