﻿// ************************************************************************************
// FileName: StartView.xaml.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.View
{
  using System.Windows;
  using ViewModel;

  /// <summary>
  ///   Interaction logic for StartView.xaml
  /// </summary>
  public partial class StartView : Window
  {
    public StartView()
    {
      InitializeComponent();
      DataContext = new StartViewModel(this);
    }
  }
}