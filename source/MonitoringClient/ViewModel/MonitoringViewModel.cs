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

    private ObservableCollection<IEntity> _logEntries;

    private IEntity _selectedEntity;
    private IMonitoringRepository MonitoringRepository { get; set; }
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

    public ObservableCollection<IEntity> LogEntries
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


    public bool CanConnectToDb()
    {
      return !IsDbConnect;
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

    private bool CanLoadAndAdd()
    {
      return IsDbConnect;
    }

    private void InitalViewModel()
    {
      LogEntries = new ObservableCollection<IEntity>();
      ConnectCommand = new DelegateCommand(OnCmdConncet, CanConnectToDb);
      AddCommand = new DelegateCommand(OnCmdAdd, CanLoadAndAdd);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm, OnCanConfirm);
      LoadCommand = new DelegateCommand(OnCmdLoad, CanLoadAndAdd);
      ContentTextBox = "Server=localhost;Database=inventarisierungsloesungv2;Uid=root;pwd=halo1velo";
    }


    private bool OnCanConfirm()
    {
      return LogEntries.Count > 0;
    }

    private void OnCmdAdd()
    {
      AddLogEntryViewModel.GetAddLogEntryViewModel.FillComboboxen();
      NavigateToLogView();
    }
    public void NavigateToLogView()
    {
      var mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.AddLogEntryVisibility = Visibility.Visible;
      mainUserControl.MonitoringVisibility = Visibility.Collapsed;
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
        MonitoringRepository.SetConnectionString(inputConnectionString);;
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