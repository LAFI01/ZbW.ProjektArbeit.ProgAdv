// ************************************************************************************
// FileName: MonitoringView1.xaml.cs
// Author: 
// Created on: 14.05.2019
// Last modified on: 14.05.2019
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
  ///   Interaction logic for MonitoringView1.xaml
  /// </summary>
  public partial class MonitoringView1 : UserControl
  {
    public MonitoringView1()
    {
      InitializeComponent();
      DataContext = new MonitoringViewModel();
    }
  }
}