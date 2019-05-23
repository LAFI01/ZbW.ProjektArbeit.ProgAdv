// ************************************************************************************
// FileName: MonitoringView.xaml.cs
// Author: 
// Created on: 14.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.View
{
  using System.Windows.Controls;
  using Persistence;
  using ViewModel;

  /// <summary>
  ///   Interaction logic for MonitoringView.xaml
  /// </summary>
  public partial class MonitoringView : UserControl
  {
    public MonitoringView()
    {
      InitializeComponent();
      IMonitoringRepository monitoringRepository = new MonitoringRepository();
      DataContext = new MonitoringViewModel(monitoringRepository);
    }
  }
}