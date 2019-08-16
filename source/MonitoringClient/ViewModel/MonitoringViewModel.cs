// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 16.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Windows;
  using DuplicateCheckerLib;
  using Model.Impl;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Persistence.View;
  using Persistence.View.Impl;
  using PluginLoader;
  using Prism.Commands;
  using Utilities.Impl;
  using IEntity = Model.IEntity;

  public class MonitoringViewModel : BindableBase
  {
    private string _destinationPath;

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

    public DelegateCommand CustomerCommand { get; set; }

    public string DestinationPath
    {
      get { return _destinationPath; }
      set
      {
        SetProperty(ref _destinationPath, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

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

    public DelegateCommand ToCsvCommand { get; set; }

    public DelegateCommand ToJsonCommand { get; set; }

    public DelegateCommand ToTxtCommand { get; set; }

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


    public void OnCmdLoad()
    {
      LogEntries = LogEntryView.GetAllLogEntries();
      RaisCanExecuteChangeHasAnyLogEntries();
    }


    public void OnCmdNavigateToCustomerView()
    {
      CustomerViewModel.GetInstance().LoadCustomers();
      MainUserControl.MonitoringVisibility = Visibility.Collapsed;
      MainUserControl.CustomerVisibility = Visibility.Visible;
    }

    public void OnCmdNavigateToLocationView()
    {
      LocationViewModel.GetInstance().LoadLocationTree();
      MainUserControl.MonitoringVisibility = Visibility.Collapsed;
      MainUserControl.LocationVisibility = Visibility.Visible;
    }


    public void RefreshView()
    {
      LogEntries = LogEntryView.GetAllLogEntries();
      RaisCanExecuteChangeHasAnyLogEntries();
    }


    private bool CanUseDb()
    {
      return IsDbConnect;
    }

    private void ExportFile(DataExporter dataExporter)
    {
      try
      {
        var msg = PluginLoader.ExportFile<LogEntry>(LogEntries, DestinationPath, dataExporter)
          ? "Export Success"
          : "Export faild";
        MessageBox.Show(msg);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private bool HasAnyLogEntries()
    {
      return LogEntries.Count > 0;
    }

    private void InitalViewModel()
    {
      LogEntries = new List<IEntity>();
      ConnectCommand = new DelegateCommand(OnCmdConnect, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanUseDb);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, HasAnyLogEntries);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanUseDb);
      DuplicatedCommand = new DelegateCommand(OnCmdDuplicatCheck, HasAnyLogEntries);
      LocationTreeCommand = new DelegateCommand(OnCmdNavigateToLocationView, CanUseDb);
      CustomerCommand = new DelegateCommand(OnCmdNavigateToCustomerView, CanUseDb);
      ToCsvCommand = new DelegateCommand(OnCmdToCsv, HasAnyLogEntries);
      ToJsonCommand = new DelegateCommand(OnCmdToJson, HasAnyLogEntries);
      ToTxtCommand = new DelegateCommand(OnCmdToTxt, HasAnyLogEntries);
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetInstance().FillComboboxen();
      MainUserControl.AddLogEntryVisibility = Visibility.Visible;
      MainUserControl.MonitoringVisibility = Visibility.Collapsed;
    }

    private void OnCmdConfirm()
    {
      LogRepository.ClearLogEntry(SelectedEntity);
      RefreshView();
    }

    private void OnCmdConnect()
    {
      try
      {
        LogEntryView.ConnectionTest();
        IsDbConnect = true;
        AddCommand.RaiseCanExecuteChanged();
        LoadCommand.RaiseCanExecuteChanged();
        ConnectCommand.RaiseCanExecuteChanged();
        CustomerCommand.RaiseCanExecuteChanged();
        LocationTreeCommand.RaiseCanExecuteChanged();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
          ex.Message);
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

    private void OnCmdToCsv()
    {
      ExportFile(DataExporter.CsvDataExporter);
    }

    private void OnCmdToJson()
    {
      ExportFile(DataExporter.JsonDataExporter);
    }

    private void OnCmdToTxt()
    {
      ExportFile(DataExporter.BinaryDataExporter);
    }

    private void RaisCanExecuteChangeHasAnyLogEntries()
    {
      ConfirmCommand.RaiseCanExecuteChanged();
      DuplicatedCommand.RaiseCanExecuteChanged();
      ToCsvCommand.RaiseCanExecuteChanged();
      ToJsonCommand.RaiseCanExecuteChanged();
      ToTxtCommand.RaiseCanExecuteChanged();
    }
  }
}