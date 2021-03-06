﻿// ************************************************************************************
// FileName: MainUserControlViewModel.cs
// Author: 
// Created on: 17.05.2019
// Last modified on: 16.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows;
  using Utilities.Impl;

  public class MainUserControlViewModel : BindableBase
  {
    private static Visibility _addLogEntryView = Visibility.Collapsed;

    private static Visibility _customerDetailView = Visibility.Collapsed;

    private static Visibility _customerView = Visibility.Collapsed;

    private static Visibility _locationView = Visibility.Collapsed;

    private static Visibility _monitoringView = Visibility.Visible;


    public Visibility AddLogEntryVisibility
    {
      get { return _addLogEntryView; }
      set { SetProperty(ref _addLogEntryView, value); }
    }

    public Visibility CustomerDetailVisibility
    {
      get { return _customerDetailView; }
      set { SetProperty(ref _customerDetailView, value); }
    }

    public Visibility CustomerVisibility
    {
      get { return _customerView; }
      set { SetProperty(ref _customerView, value); }
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