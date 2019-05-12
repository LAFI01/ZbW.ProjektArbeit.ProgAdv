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
  using System.Windows;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
  using Model;
  using Persistence;
  using Utilities;
  using View;

  public class MonitoringViewModel : BindableBase
  {
    private ObservableCollection<ILogEntry> _logEntries;

    private ILogEntry _selectedLogEntry;

    public MonitoringViewModel(string connString)
    {
      ConnString = connString;
      LogEntries = new ObservableCollection<ILogEntry>();
      MonitoringRepository = new MonitoringRepository(connString);
      CreateLoadCommand();
      CreateConfirmCommand();
      CreateAddCommand();
    }

    public ICommand AddCommand { get; set; }

    public ICommand ConfirmCommand { get; set; }

    public ICommand LoadCommand { get; set; }

    public ObservableCollection<ILogEntry> LogEntries
    {
      get { return _logEntries; }
      set
      {
        _logEntries = value;
        NotifyPropertyChanged("LogEntries");
      }
    }

    public ILogEntry SelectedLogEntry
    {
      get { return _selectedLogEntry; }
      set
      {
        _selectedLogEntry = value;
        NotifyPropertyChanged("SelectedLogEntry");
      }
    }

    private string ConnString { get; }

    private MonitoringRepository MonitoringRepository { get; }


    private void AddExecute()
    {
      AddLogEntryView addLogEntry = new AddLogEntryView(ConnString);
      addLogEntry.Show();
    }

    private void CreateAddCommand()
    {
      AddCommand = new RelayCommand(AddExecute, TrueFunc);
    }

    private void CreateConfirmCommand()
    {
      ConfirmCommand = new RelayCommand(ExecuteConfirm, TrueFunc);
    }

    private void CreateLoadCommand()
    {
      LoadCommand = new RelayCommand(LoadExecute, TrueFunc);
    }

    private void ExecuteConfirm()
    {
      if (SelectedLogEntry == null)
      {
        MessageBox.Show("Please selected a log entry");
      }

      MonitoringRepository.ClearLogEntriy(_selectedLogEntry);
    }

    private void LoadExecute()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
      foreach (ILogEntry log in LogEntries)
      {
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, log));
      }
    }

    private bool TrueFunc()
    {
      return true;
    }
  }
}