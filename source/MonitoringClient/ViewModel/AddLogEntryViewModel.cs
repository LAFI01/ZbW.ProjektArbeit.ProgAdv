// ************************************************************************************
// FileName: AddLogEntryViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 27.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.Generic;
  using System.Reflection;
  using System.Windows;
  using Model;
  using Model.Impl;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Persistence.View;
  using Persistence.View.Impl;
  using Prism.Commands;
  using Prism.Mvvm;
  using Utilities.Impl;

  public class AddLogEntryViewModel : BindableBase
  {
    private const int InitialDeviceId = 0;

    private List<int> _deviceIds;

    private List<string> _hostnameItems;

    private int _selectedDeviceId;

    private string _selectedHostnameItem;

    private string _selectedSeverityItem;

    private List<string> _serverityItems;

    private string _text;

    public AddLogEntryViewModel(ILogEntryView logEntryView, IDeviceRepository deviceRepository,
      ILogRepository logRepository)
    {
      LogEntryView = logEntryView;
      DeviceRepository = deviceRepository;
      LogRepository = logRepository;
      InitialViewModel();
    }

    public DelegateCommand CancelCommand { get; set; }


    public List<int> DeviceIds
    {
      get
      {
        _deviceIds?.Sort();

        return _deviceIds;
      }
      set
      {
        SetProperty(ref _deviceIds, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public List<string> HostnameItems
    {
      get { return _hostnameItems; }
      set
      {
        SetProperty(ref _hostnameItems, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
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


    public List<string> SeverityItems
    {
      get { return _serverityItems; }
      set
      {
        SetProperty(ref _serverityItems, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        SaveCommand.RaiseCanExecuteChanged();
      }
    }


    public string Text
    {
      get { return _text; }
      set
      {
        if (value.Length > ConstantValue.MaximumFourthyFiveSigns)
        {
          MessageBox.Show(string.Concat(ErrorMessage.InputStringTooLong, ConstantValue.MaximumFourthyFiveSigns));
        }
        else
        {
          SetProperty(ref _text, value);
          RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        }
      }
    }

    private IDeviceRepository DeviceRepository { get; }

    private static AddLogEntryViewModel Instance { get; set; }

    private ILogEntryView LogEntryView { get; }

    private ILogRepository LogRepository { get; }


    public void FillComboboxen()
    {
      DeviceIds = DeviceRepository.GetDeviceIds();
      HostnameItems = DeviceRepository.GetDeviceHostname();
    }

    public static AddLogEntryViewModel GetInstance()
    {
      if (Instance == null)
      {
        ILogEntryView logEntryView = new LogEntryView();
        IDeviceRepository deviceRepository = new DeviceRepository();
        ILogRepository logRepository = new LogRepository();
        Instance = new AddLogEntryViewModel(logEntryView, deviceRepository, logRepository);
      }

      return Instance;
    }

    public void InitialViewModel()
    {
      CancelCommand = new DelegateCommand(OnCmdNavigateToMonitoringView);
      SaveCommand = new DelegateCommand(OnCmdSave, CanSave);
      SeverityItems = Severity.Severities;
    }

    public void OnCmdNavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.AddLogEntryVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }

    private bool CanSave()
    {
      return SelectedHostnameItem != null && SelectedSeverityItem != null && SelectedDeviceId != InitialDeviceId;
    }


    private void OnCmdSave()
    {
      if (!string.IsNullOrEmpty(Text))
      {
        IEntity entity = new LogEntry(SelectedHostnameItem, Text, SelectedSeverityItem);
        entity.DeviceId = SelectedDeviceId;
        LogRepository.AddLogEntry(entity);
        OnCmdNavigateToMonitoringView();
        MonitoringViewModel.GetInstance().RefreshView();
      }
      else
      {
        MessageBox.Show(ErrorMessage.PleaseEnterMessage);
      }
    }
  }
}