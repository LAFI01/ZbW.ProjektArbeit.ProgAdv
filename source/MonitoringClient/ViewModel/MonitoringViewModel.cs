// ************************************************************************************
// FileName: MonitoringViewModel.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.ObjectModel;
  using System.Collections.Specialized;
  using System.Reflection;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using Model;
  using Persistence;
  using View;
  using Prism.Commands;
  using Prism.Mvvm;
  using Properties;

  public class MonitoringViewModel : BindableBase
  {
    private ObservableCollection<ILogEntry> _logEntries;

    private ILogEntry _selectedLogEntry;

    private string _connString;

    private UserControl _content;

    public MonitoringViewModel()
    {
      //Content = content;
      LogEntries = new ObservableCollection<ILogEntry>();      
      AddCommand = new DelegateCommand(OnCmdAdd);
      ConfirmCommand = new DelegateCommand(OnCmdConfirm);
      LoadCommand = new DelegateCommand(OnCmdLoad);
    }
    public UserControl Content
    {
      get { return _content; }

      set { SetProperty(ref _content, value); }
    }

    public void OnCmdLoad()
    {
      LoadExecute();
    }

    private void OnCmdConfirm()
    {
      MonitoringRepository.ClearLogEntriy(SelectedLogEntry);
      RefreshLogEntries();
    }

    private void OnCmdAdd()
    {
      NavigationToAddLogEntryView();
    }

    private void NavigationToAddLogEntryView()
    {
      //Content.Visibility = Visibility.Collapsed;
      //Content = new AddLogEntryView();
      //Content.Visibility = Visibility.Visible;
    }



    public ICommand AddCommand { get; set; }

    public ICommand ConfirmCommand { get; set; }

    public ICommand LoadCommand { get; set; }

    public ObservableCollection<ILogEntry> LogEntries
    {
      get { return _logEntries; }
      set
      {
        SetProperty(ref _logEntries, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }
  

    public string GetConetentTextBox
    {
      get { return _connString; }
      set
      {
        SetProperty(ref _connString, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public ILogEntry SelectedLogEntry
    {
      get { return _selectedLogEntry; }
      set
      {
        SetProperty(ref _selectedLogEntry, value);

        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private MonitoringRepository MonitoringRepository { get; set; }



    private void LoadExecute()
    {
      if (Settings.Default.ConnectionString == null)
      {
        Settings.Default.ConnectionString = GetConetentTextBox;
      }
      MonitoringRepository = new MonitoringRepository();
      LogEntries = MonitoringRepository.GetAllLogEntries();
    }

    private void RefreshLogEntries()
    {
      LogEntries = MonitoringRepository.GetAllLogEntries();
    }

  }
}