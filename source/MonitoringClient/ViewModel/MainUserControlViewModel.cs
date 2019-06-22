// ************************************************************************************
// FileName: MainUserControlViewModel.cs
// Author: 
// Created on: 17.05.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows;
  using Prism.Mvvm;

  public class MainUserControlViewModel : BindableBase
  {
    private static Visibility _addLogEntryView = Visibility.Hidden;

    private static Visibility _locationView = Visibility.Hidden;

    private static Visibility _monitoringView = Visibility.Visible;

    public Visibility AddLogEntryVisibility
    {
      get { return _addLogEntryView; }
      set { SetProperty(ref _addLogEntryView, value); }
    }

    public Visibility LocationVisibility
    {
      get { return _locationView; }
      set { SetProperty(ref _locationView, value); }
    }

    public Visibility MonitoringVisibility
    {
      get { return _monitoringView; }
      set { SetProperty(ref _monitoringView, value); }
    }

    private static MainUserControlViewModel Instance { get; set; }

    public static MainUserControlViewModel GetInstance()
    {
      if (Instance == null)
      {
        Instance = new MainUserControlViewModel();
      }

      return Instance;
    }
  }
}