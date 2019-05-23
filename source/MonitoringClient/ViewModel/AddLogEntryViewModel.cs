// ************************************************************************************
// FileName: AddLogEntryViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 18.05.2019
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

  public class AddLogEntryViewModel : BindableBase
  {
    private const int InitialDeviceId = 0;

    private const int MaxLengthOfSign = 45;

    private ObservableCollection<int> _deviceIds;

    private ObservableCollection<string> _hostnameItems;

    private string _message;

    private int _selectedDeviceId;

    private string _selectedHostnameItem;

    private string _selectedSeverityItem;

    private ObservableCollection<string> _serverityItems;
    private IMonitoringRepository MonitoringRepository { get; set; }
    public AddLogEntryViewModel(IMonitoringRepository monitoringRepository)
    {
      MonitoringRepository = monitoringRepository;
      InitalView();
    }

    public void InitalView()
    {
      GetAddLogEntryViewModel = this;
      CancelCommand = new DelegateCommand(OnCmdCancel);
      SaveCommand = new DelegateCommand(OnCmdSave, CanSave);
      SeverityItems = Severity.Severities;
    }

    public static DelegateCommand CancelCommand { get; set; }


    public ObservableCollection<int> DeviceIds
    {
      get { return _deviceIds; }
      set
      {
        SetProperty(ref _deviceIds, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public static AddLogEntryViewModel GetAddLogEntryViewModel { get; private set; }

    public ObservableCollection<string> HostnameItems
    {
      get { return _hostnameItems; }
      set
      {
        SetProperty(ref _hostnameItems, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public string Message
    {
      get { return _message; }
      set
      {
        if (value.Length > MaxLengthOfSign)
        {
          MessageBox.Show(string.Format($"Message is too long. Maximum {MaxLengthOfSign} signs"));
        }
        else
        {
          SetProperty(ref _message, value);
          RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        }
      }
    }


    public DelegateCommand SaveCommand { get; set; }


    public int SelectedDeviceId
    {
      get { return _selectedDeviceId; }
      set
      {
        SetProperty(ref _selectedDeviceId, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        SaveCommand.RaiseCanExecuteChanged();
      }
    }

    public string SelectedHostnameItem
    {
      get { return _selectedHostnameItem; }
      set
      {
        SetProperty(ref _selectedHostnameItem, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        SaveCommand.RaiseCanExecuteChanged();
      }
    }

    public string SelectedSeverityItem
    {
      get { return _selectedSeverityItem; }
      set
      {
        SetProperty(ref _selectedSeverityItem, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        SaveCommand.RaiseCanExecuteChanged();
      }
    }


    public ObservableCollection<string> SeverityItems
    {
      get { return _serverityItems; }
      set
      {
        SetProperty(ref _serverityItems, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        SaveCommand.RaiseCanExecuteChanged();
      }
    }

    public void FillComboboxen()
    {
      DeviceIds = MonitoringRepository.GetAllDeviceIds();
      HostnameItems = MonitoringRepository.GetAllHostname();
    }

    private bool CanSave()
    {
      return SelectedHostnameItem != null && (SelectedSeverityItem != null) & (SelectedDeviceId != InitialDeviceId);
    }


    private void OnCmdCancel()
    {
      NavigateToMonitoringView();
    }
    public void NavigateToMonitoringView()
    {
      var mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.AddLogEntryVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }

    private void OnCmdSave()
    {
      IEntity entity = new LogEntry(SelectedHostnameItem, Message, SelectedSeverityItem);
      entity.DeviceId = SelectedDeviceId;
      MonitoringRepository.AddLogEntriy(entity);
      NavigateToMonitoringView();
      MonitoringViewModel.GetMonitoringViewModel.RefreshLogEntries();
    }
  }
}