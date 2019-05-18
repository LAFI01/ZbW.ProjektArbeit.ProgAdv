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
  using Model;
  using Persistence;
  using Prism.Commands;
  using Prism.Mvvm;
  using Properties;

  public class MonitoringViewModel : BindableBase
  {
    private const int MaxLengthOfConnectionString = 100;

    private string _connString;

    private ObservableCollection<ILogEntry> _logEntries;

    private ILogEntry _selectedLogEntry;

    public MonitoringViewModel()
    {
      GetMonitoringViewModel = this;
      InitalViewModel();
    }


    public DelegateCommand AddCommand { get; set; }

    public DelegateCommand ConfirmCommand { get; set; }


    public DelegateCommand ConnectCommand { get; set; }


    public string ContentTextBox
    {
      get { return _connString; }
      set
      {
        SetProperty(ref _connString, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public static MonitoringViewModel GetMonitoringViewModel { get; private set; }

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

    private MainUserControlViewModel MainUserControlViewModel { get; set; }

    private MonitoringRepository MonitoringRepository { get; set; }

    public bool CanConnectToDb()
    {
      return !IsDbConnect;
    }

    public void OnCmdLoad()
    {
      MonitoringRepository = new MonitoringRepository();
      LogEntries = MonitoringRepository.GetAllLogEntries();
      ConfirmCommand.RaiseCanExecuteChanged();
    }

    public void RefreshLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
    }

    private bool CanLoadAndAdd()
    {
      return IsDbConnect;
    }

    private void InitalViewModel()
    {
      MainUserControlViewModel = MainUserControlViewModel.GetMainUserControlViewModel;
      LogEntries = new ObservableCollection<ILogEntry>();
      ConnectCommand = new DelegateCommand(OnCmdConncet, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanLoadAndAdd);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, OnCanConfirm);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanLoadAndAdd);
      ContentTextBox = "Server=;Database=;Uid=;pwd=";
    }


    private bool OnCanConfirm()
    {
      return LogEntries.Count > 0;
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetAddLogEntryViewModel.FillComboboxen();
      MainUserControlViewModel.SetAddLogEntryAsView();
    }

    private void OnCmdConfirm()
    {
      MonitoringRepository.ClearLogEntriy(SelectedLogEntry);
      RefreshLogEntries();
    }

    private void OnCmdConncet()
    {
      var inputConnectionString = ContentTextBox;
      if (inputConnectionString != null && inputConnectionString.Length < MaxLengthOfConnectionString)
      {
        Settings.Default.ConnectionString = inputConnectionString;
        MonitoringRepository = new MonitoringRepository();
        if (!MonitoringRepository.ConnectionTest())
        {
          MessageBox.Show("It coud not connect to your database!");
        }
        else
        {
          IsDbConnect = true;
          AddCommand.RaiseCanExecuteChanged();
          LoadCommand.RaiseCanExecuteChanged();
          ConnectCommand.RaiseCanExecuteChanged();
        }
      }
      else
      {
        MessageBox.Show("Your input connection string is not correct");
      }
    }
  }
}