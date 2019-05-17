// ************************************************************************************
// FileName: AddLogEntryViewModel.cs
// Author: 
// Created on: 12.05.2019
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
  using System.Windows.Input;
  using Model;
  using Prism.Mvvm;

  public class AddLogEntryViewModel : BindableBase
  {
    private ObservableCollection<int> _deviceIds;

    private ObservableCollection<string> _hostnameItems;

    private string _message;

    private int _selectedDeviceId;

    private string _selectedHostnameItem;

    private string _selectedSeverityItem;

    private ObservableCollection<string> _serverityItems;

    public AddLogEntryViewModel()
    {
      //MonitoringRepository = null;
      //DeviceIds = MonitoringRepository.GetAllDeviceIds();
      //HostnameItems = MonitoringRepository.GetAllHostname();

      SeverityItems = Severity.Severities;
    }

    public ICommand CancelCommand { get; set; }


    public ObservableCollection<int> DeviceIds
    {
      get { return _deviceIds; }
      set
      {
        SetProperty(ref _deviceIds, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

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
        SetProperty(ref _message, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public ICommand SaveCommand { get; set; }


    public int SelectedDeviceId
    {
      get { return _selectedDeviceId; }
      set
      {
        SetProperty(ref _selectedDeviceId, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string SelectedHostnameItem
    {
      get { return _selectedHostnameItem; }
      set
      {
        SetProperty(ref _selectedHostnameItem, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public string SelectedSeverityItem
    {
      get { return _selectedSeverityItem; }
      set
      {
        SetProperty(ref _selectedSeverityItem, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public ObservableCollection<string> SeverityItems
    {
      get { return _serverityItems; }
      set
      {
        SetProperty(ref _serverityItems, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    //private MonitoringRepository MonitoringRepository { get; }


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