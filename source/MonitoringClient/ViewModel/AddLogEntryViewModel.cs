// ************************************************************************************
// FileName: AddLogEntryViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 09.06.2019
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

  public class AddLogEntryViewModel : BindableBase
  {
    private const int InitialDeviceId = 0;

    private const int MaxLengthOfSign = 45;

    private List<int> _deviceIds;

    private List<string> _hostnameItems;

    private int _selectedDeviceId;

    private string _selectedHostnameItem;

    private string _selectedSeverityItem;

    private List<string> _serverityItems;

    private string _text;

    public AddLogEntryViewModel(ILogEntryView logEntryView)
    {
      LogEntryView = logEntryView;
      InitalView();
    }

    public static DelegateCommand CancelCommand { get; set; }


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
        if (value.Length > MaxLengthOfSign)
        {
          MessageBox.Show(string.Format($"Text is too long. Maximum {MaxLengthOfSign} signs"));
        }
        else
        {
          SetProperty(ref _text, value);
          RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
        }
      }
    }

    private static AddLogEntryViewModel Instance { get; set; }

    private ILogEntryView LogEntryView { get; }

    public void FillComboboxen()
    {
      IDeviceRepository deviceRepo = new DeviceRepository();
      DeviceIds = deviceRepo.GetDeviceIds();
      HostnameItems = deviceRepo.GetDeviceHostname();
    }

    public static AddLogEntryViewModel GetInstance()
    {
      if (Instance == null)
      {
        ILogEntryView logEntryView = new LogentriyView();
        Instance = new AddLogEntryViewModel(logEntryView);
      }

      return Instance;
    }

    public void InitalView()
    {
      CancelCommand = new DelegateCommand(OnCmdCancel);
      SaveCommand = new DelegateCommand(OnCmdSave, CanSave);
      SeverityItems = Severity.Severities;
    }

    public void NavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.AddLogEntryVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }

    private bool CanSave()
    {
      return SelectedHostnameItem != null && SelectedSeverityItem != null && SelectedDeviceId != InitialDeviceId;
    }


    private void OnCmdCancel()
    {
      NavigateToMonitoringView();
    }

    private void OnCmdSave()
    {
      if (!string.IsNullOrEmpty(Text))
      {
        LogRepository logRepo = new LogRepository();
        IEntity entity = new LogEntry(SelectedHostnameItem, Text, SelectedSeverityItem);
        entity.DeviceId = SelectedDeviceId;
        logRepo.AddLogEntry(entity);
        NavigateToMonitoringView();
        MonitoringViewModel.GetInstance().RefreshLogEntries();
      }
      else
      {
        MessageBox.Show("Please enter a message");
      }
    }
  }
}