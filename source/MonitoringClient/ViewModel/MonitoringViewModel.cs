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
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Windows;
  using DuplicateCheckerLib;
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

    public DelegateCommand DuplicatedCommand { get; set; }

    public DelegateCommand LoadCommand { get; set; }


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

    private IMonitoringRepository MonitoringRepository { get; }


    public bool CanConnectToDb()
    {
      return !IsDbConnect;
    }

    public static MonitoringViewModel GetInstance()
    {
      if (Instance == null)
      {
        IMonitoringRepository monitoringRepository = new MonitoringRepository();
        Instance = new MonitoringViewModel(monitoringRepository);
      }

      return Instance;
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
      DuplicatedCommand.RaiseCanExecuteChanged();
    }

    public void RefreshLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
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
      ContentTextBox = "Server=localhost;Database=inventarisierungsloesunglfi;Uid=root;pwd=halo1velo";
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetInstance().FillComboboxen();
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