// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 25.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Reflection;
  using System.Windows;
  using DuplicateCheckerLib;
  using Model;
  using Persistence;
  using Prism.Commands;
  using Prism.Mvvm;
  using IEntity = Model.IEntity;

  public class MonitoringViewModel : BindableBase
  {
    private const int MaxLengthOfConnectionString = 100;

    private string _connString;

    private List<IEntity> _logEntries;

    private IEntity _selectedEntity;

    public MonitoringViewModel(IMonitoringRepository monitoringRepository)
    {
      GetMonitoringViewModel = this;
      MonitoringRepository = monitoringRepository;
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
    public DelegateCommand DuplicatedCommand { get; set; }


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

    private bool IsDbConnect { get; set; }

    private IMonitoringRepository MonitoringRepository { get; }


    public bool CanConnectToDb()
    {
      return !IsDbConnect;
    }

    public void NavigateToLogView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.AddLogEntryVisibility = Visibility.Visible;
      mainUserControl.MonitoringVisibility = Visibility.Collapsed;
    }

    public void OnCmdLoad()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
      ConfirmCommand.RaiseCanExecuteChanged();
    }

    public void RefreshLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
      ConfirmCommand.RaiseCanExecuteChanged();
    }

    private bool CanUseDb()
    {
      return IsDbConnect;
    }

    private void InitalViewModel()
    {
      LogEntries = new List<IEntity>();
      ConnectCommand = new DelegateCommand(OnCmdConncet, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanUseDb);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, HasAnyLogEntries);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanUseDb);
      DuplicatedCommand = new DelegateCommand(OnCmdDuplicatCheck, HasAnyLogEntries);
      ContentTextBox = "Server=localhost;Database=inventarisierungsloesungv2;Uid=root;pwd=halo1velo";
    }

    private void OnCmdDuplicatCheck()
    {
      var list = new List<IEntity> { new LogEntry(null, null, null)
      {
        Id = 1, Severity = "", Text = "a"
      }, new LogEntry(null, null, null)
        {
          Id = 2, Severity = "Debug", Text = "Debug"
        }, new LogEntry(null, null, null) { Id = 3, Severity = "Debug", Text = "c" },
        new LogEntry(null, null, null) { Id = 4, Severity = "Debug", Text = "b" },
        new LogEntry(null, null, null) { Id = 5, Severity = "Debug", Text = "b" },
        new LogEntry(null, null, null) { Id = 6, Severity = "warn", Text = "a" } };
      var dupChecker = new DuplicateChecker();
      //var dupList = dupChecker.FindDuplicates(list);

      //var dupChecker = new DuplicateChecker();
      //System.Collections.Generic.IEnumerable<DuplicateCheckerLib.IEntity> a = new DuplicateCheckerLib.IEntity[5];
      //DuplicateCheckerLib.IEntity[] b = new DuplicateCheckerLib.IEntity[5];

      //var dupList = dupChecker.FindDuplicates(LogEntries);
    }

    //private void MapToDu(List<IEntity> list)
    //{
    //  DuplicateCheckerLib.IEntity[] b = new DuplicateCheckerLib.IEntity[list.Count];
    //  for (int i = 0; i < list.Count; i++)
    //  {
    //    b[i]
    //  }

    //}


    private bool HasAnyLogEntries()
    {
      //return LogEntries.Count > 0;
      return true;
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetAddLogEntryViewModel.FillComboboxen();
      NavigateToLogView();
    }

    private void OnCmdConfirm()
    {
      MonitoringRepository.ClearLogEntriy(SelectedEntity);
      RefreshLogEntries();
    }

    private void OnCmdConncet()
    {
      var inputConnectionString = ContentTextBox;
      if (inputConnectionString != null && inputConnectionString.Length < MaxLengthOfConnectionString)
      {
        MonitoringRepository.SetConnectionString(inputConnectionString);
        ;
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