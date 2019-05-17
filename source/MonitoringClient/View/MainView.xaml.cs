// ************************************************************************************
// FileName: MainView.xaml.cs
// Author: 
// Created on: 14.05.2019
// Last modified on: 16.05.2019
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
  ///   Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : Window
  {
    public MainView()
    {
      InitializeComponent();
      DataContext = new MainViewModel();
    }
  }
}