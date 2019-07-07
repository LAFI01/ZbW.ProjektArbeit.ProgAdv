// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Windows;
  using DuplicateCheckerLib;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Persistence.View;
  using Persistence.View.Impl;
  using Prism.Commands;
  using Prism.Mvvm;
  using IEntity = Model.IEntity;

  public class MonitoringViewModel : BindableBase
  {
    private List<IEntity> _logEntries;

    private IEntity _selectedEntity;

    public MonitoringViewModel(ILogEntryView logEntryView, ILogRepository logRepository)
    {
      MainUserControl = MainUserControlViewModel.GetInstance();
      LogEntryView = logEntryView;
      LogRepository = logRepository;
      InitalViewModel();
    }


    public DelegateCommand AddCommand { get; set; }

    public DelegateCommand ConfirmCommand { get; set; }

    public DelegateCommand ConnectCommand { get; set; }

    public DelegateCommand DuplicatedCommand { get; set; }

    public DelegateCommand LoadCommand { get; set; }

    public DelegateCommand LocationTreeCommand { get; set; }

    public List<IEntity> LogEntries
    {
      get { return _logEntries; }
      set
      {
        SetProperty(ref _logEntries, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public IEntity SelectedEntity
    {
      get { return _selectedEntity; }
      set
      {
        SetProperty(ref _selectedEntity, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private static MonitoringViewModel Instance { get; set; }

    private bool IsDbConnect { get; set; }

    private ILogEntryView LogEntryView { get; }

    private ILogRepository LogRepository { get; }

    private MainUserControlViewModel MainUserControl { get; }

    public bool CanConnectToDb()
    {
      return !IsDbConnect;
    }

    public static MonitoringViewModel GetInstance()
    {
      if (Instance == null)
      {
        LogEntryView monitoringRepository = new LogEntryView();
        LogRepository logRepository = new LogRepository();
        Instance = new MonitoringViewModel(monitoringRepository, logRepository);
      }

      return Instance;
    }

    public void NavigateToLogView()
    {
      MainUserControl.AddLogEntryVisibility = Visibility.Visible;
      MainUserControl.MonitoringVisibility = Visibility.Collapsed;
      MainUserControl.LocationVisibility = Visibility.Collapsed;
    }

    public void OnCmdLoad()
    {
      LogEntries = LogEntryView.GetAllLogEntries();
      ConfirmCommand.RaiseCanExecuteChanged();
      DuplicatedCommand.RaiseCanExecuteChanged();
      LocationTreeCommand.RaiseCanExecuteChanged();
    }

    public void OnCmdNavigateToLocationView()
    {
      LocationViewModel.GetInstance().LoadLocationTree();
      MainUserControl.AddLogEntryVisibility = Visibility.Collapsed;
      MainUserControl.MonitoringVisibility = Visibility.Collapsed;
      MainUserControl.LocationVisibility = Visibility.Visible;
    }

    public void RefreshLogEntries()
    {
      LogEntries = LogEntryView.GetAllLogEntries();
      ConfirmCommand.RaiseCanExecuteChanged();
      DuplicatedCommand.RaiseCanExecuteChanged();
    }


    private bool CanUseDb()
    {
      return IsDbConnect;
    }

    private bool HasAnyLogEntries()
    {
      return LogEntries.Count > 0;
    }

    private void InitalViewModel()
    {
      LogEntries = new List<IEntity>();
      ConnectCommand = new DelegateCommand(OnCmdConncet, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanUseDb);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, HasAnyLogEntries);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanUseDb);
      DuplicatedCommand = new DelegateCommand(OnCmdDuplicatCheck, HasAnyLogEntries);
      LocationTreeCommand = new DelegateCommand(OnCmdNavigateToLocationView, HasAnyLogEntries);
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetInstance().FillComboboxen();
      NavigateToLogView();
    }

    private void OnCmdConfirm()
    {
      LogRepository.ClearLogEntry(SelectedEntity);
      RefreshLogEntries();
    }

    private void OnCmdConncet()
    {
      if (!LogEntryView.ConnectionTest())
      {
        MessageBox.Show(
          "It coud not connect to your database! Please check the Connection String in your app.config file");
      }
      else
      {
        IsDbConnect = true;
        AddCommand.RaiseCanExecuteChanged();
        LoadCommand.RaiseCanExecuteChanged();
        ConnectCommand.RaiseCanExecuteChanged();
      }
    }

    private void OnCmdDuplicatCheck()
    {
      DuplicateChecker dupChecker = new DuplicateChecker();
      var dupList = dupChecker.FindDuplicates(LogEntries);
      if (dupList.Any())
      {
        var newEntities = new List<IEntity>();
        foreach (DuplicateCheckerLib.IEntity d in dupList)
        {
          newEntities.Add(d as IEntity);
        }

        LogEntries.Clear();
        LogEntries = newEntities;
      }
      else
      {
        MessageBox.Show("There are no duplicated Log Entries");
      }
    }
  }
}