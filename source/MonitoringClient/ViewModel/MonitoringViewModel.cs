// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.ObjectModel;
  using System.Reflection;
  using System.Windows;
  using System.Windows.Input;
  using Model;
  using Persistence;
  using Prism.Commands;
  using Prism.Mvvm;
  using Properties;

  public class MonitoringViewModel : BindableBase
  {
    private string _connString;

    private ObservableCollection<ILogEntry> _logEntries;

    private ILogEntry _selectedLogEntry;


    public MonitoringViewModel()
    {
      LogEntries = new ObservableCollection<ILogEntry>();
      ConnectCommand = new DelegateCommand(OnCmdConncet, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanLoadAndAdd);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, OnCanConfirm);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanLoadAndAdd);
    }

    public DelegateCommand AddCommand { get; set; }

    public DelegateCommand ConfirmCommand { get; set; }


    public DelegateCommand ConnectCommand { get; set; }


    public string GetConetentTextBox
    {
      get { return _connString; }
      set
      {
        SetProperty(ref _connString, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public DelegateCommand LoadCommand { get; set; }

    public ObservableCollection<ILogEntry> LogEntries
    {
      get { return _logEntries; }
      set
      {
        SetProperty(ref _logEntries, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public ILogEntry SelectedLogEntry
    {
      get { return _selectedLogEntry; }
      set
      {
        SetProperty(ref _selectedLogEntry, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private bool IsDbConnect { get; set; }

    public bool CanConnectToDb()
    {
      return !IsDbConnect;
    }

    private MonitoringRepository MonitoringRepository { get; set; }

    public void OnCmdLoad()
    {
      MonitoringRepository = new MonitoringRepository();
      LogEntries = MonitoringRepository.GetAllLogEntries();
    }

    private bool CanLoadAndAdd()
    {
      return IsDbConnect;
    }


    private void NavigationToAddLogEntryView()
    {
      //Content.Visibility = Visibility.Collapsed;
      //Content = new AddLogEntryView();
      //Content.Visibility = Visibility.Visible;
    }

    private bool OnCanConfirm()
    {
      return LogEntries.Count > 0;
    }

    private void OnCmdAdd()
    {
      NavigationToAddLogEntryView();
    }

    private void OnCmdConfirm()
    {
      MonitoringRepository.ClearLogEntriy(SelectedLogEntry);
      RefreshLogEntries();
    }

    private void OnCmdConncet()
    {
      if (Settings.Default.ConnectionString == null)
      {
        Settings.Default.ConnectionString = GetConetentTextBox;
      }

      MonitoringRepository = new MonitoringRepository();
      if (!MonitoringRepository.ConnectionTest())
      {
        MessageBox.Show("Die Verbindung zur BD konnte nicht hergestellt werden.");
      }
      else
      {
        IsDbConnect = true;
        AddCommand.RaiseCanExecuteChanged();
        LoadCommand.RaiseCanExecuteChanged();
        ConnectCommand.RaiseCanExecuteChanged();
      }
    }

    private void RefreshLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
    }
  }
}