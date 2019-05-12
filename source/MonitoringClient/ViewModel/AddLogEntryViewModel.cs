// ************************************************************************************
// FileName: AddLogEntryViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.ObjectModel;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
  using Model;
  using Persistence;
  using Utilities;
  using View;

  public class AddLogEntryViewModel : BindableBase
  {
    private ObservableCollection<int> _deviceIds;

    private ObservableCollection<string> _hostnameItems;

    private string _message;

    private int _selectedDeviceId;

    private string _selectedHostnameItem;

    private string _selectedSeverityItem;

    private ObservableCollection<string> _serverityItems;

    public AddLogEntryViewModel(string connString, AddLogEntryView addLogEntryView)
    {
      AddLogEntryView = addLogEntryView;
      MonitoringRepository = new MonitoringRepository(connString);
      CreateCancelCommand();
      CreateSaveCommand();
      DeviceIds = MonitoringRepository.GetAllDeviceIds();
      HostnameItems = MonitoringRepository.GetAllHostname();
      SeverityItems = Severity.Severities;
    }

    public ICommand CancelCommand { get; set; }

    public ObservableCollection<int> DeviceIds
    {
      get { return _deviceIds; }
      set
      {
        if (_deviceIds != value)
        {
          _deviceIds = value;
          NotifyPropertyChanged("DeviceIds");
        }
      }
    }


    public ObservableCollection<string> HostnameItems
    {
      get { return _hostnameItems; }
      set
      {
        if (_hostnameItems != value)
        {
          _hostnameItems = value;
          NotifyPropertyChanged("HostnameItems");
        }
      }
    }

    public string Message
    {
      get { return _message; }
      set
      {
        _message = value;
        NotifyPropertyChanged("Message");
        IsLogEntryValid();
      }
    }

    public ICommand SaveCommand { get; set; }

    public int SelectedDeviceId
    {
      get { return _selectedDeviceId; }
      set
      {
        _selectedDeviceId = value;
        NotifyPropertyChanged("SelectedDeviceId");
        IsLogEntryValid();
      }
    }

    public string SelectedHostnameItem
    {
      get { return _selectedHostnameItem; }
      set
      {
        _selectedHostnameItem = value;
        NotifyPropertyChanged("SelectedHostnameItem");
        IsLogEntryValid();
      }
    }

    public string SelectedSeverityItem
    {
      get { return _selectedSeverityItem; }
      set
      {
        _selectedSeverityItem = value;
        NotifyPropertyChanged("SelectedSeverityItem");
        IsLogEntryValid();
      }
    }

    public ObservableCollection<string> SeverityItems
    {
      get { return _serverityItems; }
      set
      {
        if (_serverityItems != value)
        {
          _serverityItems = value;
          NotifyPropertyChanged("SeverityItems");
        }
      }
    }

    private AddLogEntryView AddLogEntryView { get; }

    private MonitoringRepository MonitoringRepository { get; }

    private void CreateCancelCommand()
    {
      CancelCommand = new RelayCommand(ExecuteCancel, ExecuteButton);
    }

    private void CreateSaveCommand()
    {
      SaveCommand = new RelayCommand(ExecuteSave, ExecuteButton);
      AddLogEntryView.saveBtn.IsEnabled = false;
    }

    private void ExecuteCancel()
    {
      AddLogEntryView.Close();
    }

    private void ExecuteSave()
    {
      LogEntry newLogEntry = new LogEntry(SelectedHostnameItem, Message, MapSeverityToInt(SelectedSeverityItem));
      newLogEntry.DeviceId = SelectedDeviceId;
      MonitoringRepository.AddLogEntriy(newLogEntry);
      AddLogEntryView.Close();
    }

    private bool ExecuteButton()
    {
      return true;
    }

    private bool IsLogEntryValid()
    {
      var isDeviceIdValid = AddLogEntryView.deviceCombo.Text.Length >= 1;
      var isValid = SelectedSeverityItem != null && isDeviceIdValid && SelectedHostnameItem != null &&
                    Message != null;
      if (isValid)
      {
        AddLogEntryView.saveBtn.IsEnabled = true;
      }
      return isValid;
    }

    private int MapSeverityToInt(string severity)
    {
      var status = 0;
      switch (severity)
      {
        case "Error":
          status = 1;

          break;
        case "Warning":
          status = 2;

          break;
        case "Critical":
          status = 3;

          break;
        case "Low":
          status = 4;

          break;
      }

      return status;
    }
  }
}