﻿// ************************************************************************************
// FileName: MonitoringView.xaml.cs
// Author: 
// Created on: 23.05.2019
// Last modified on: 25.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.View
{
  using System.Windows.Controls;
  using ViewModel;

  /// <summary>
  ///   Interaction logic for MonitoringView.xaml
  /// </summary>
  public partial class MonitoringView : UserControl
  {
    public MonitoringView()
    {
      InitializeComponent();
      DataContext = MonitoringViewModel.GetInstance();
    }
  }
}