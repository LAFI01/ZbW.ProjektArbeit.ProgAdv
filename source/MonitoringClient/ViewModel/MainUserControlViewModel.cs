﻿// ************************************************************************************
// FileName: MainUserControlViewModel.cs
// Author: 
// Created on: 17.05.2019
// Last modified on: 17.05.2019
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
    private static Visibility _monitoringView = Visibility.Visible;

    public MainUserControlViewModel()
    {

    }

    public Visibility AddLogEntryVisibility
    {
      get { return _addLogEntryView; }
      set { SetProperty(ref _addLogEntryView, value); }
    }

    private static MainUserControlViewModel Instance { get;  set; }


    public Visibility MonitoringVisibility
    {
      get { return _monitoringView; }
      set { SetProperty(ref _monitoringView, value); }
    }

    //public void SetAddLogEntryAsView()
    //{
    //  AddLogEntryVisibility = Visibility.Visible;
    //  MonitoringVisibility = Visibility.Collapsed;
    //}

    //public void SetMonitoringAsView()
    //{
    //  MonitoringVisibility = Visibility.Visible;
    //  AddLogEntryVisibility = Visibility.Collapsed;
    //}

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