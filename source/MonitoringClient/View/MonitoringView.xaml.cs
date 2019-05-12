// ************************************************************************************
// FileName: MonitoringView.xaml.cs
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
  using System.Collections.Generic;
  using System.Windows;
  using Model;
  using ViewModel;

  /// <summary>
  ///   Interaction logic for MonitoringView.xaml
  /// </summary>
  public partial class MonitoringView : Window
  {
    public MonitoringView(string connString)
    {
      InitializeComponent();
      MonitoringViewModel = new MonitoringViewModel(connString);
      DataContext = MonitoringViewModel;
    }

    public List<ILogEntry> LogEntriesList { get; set; }

    private MonitoringViewModel MonitoringViewModel { get; }


    private void BtnLoad_Click(object sender, RoutedEventArgs e)
    {
      MonitoringViewModel.GetAllLogEntries();
    }
  }
}