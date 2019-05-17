// ************************************************************************************
// FileName: MainUserControl.xaml.cs
// Author: 
// Created on: 16.05.2019
// Last modified on: 17.05.2019
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
  ///   Interaction logic for MainUserControl.xaml
  /// </summary>
  public partial class MainUserControl : UserControl
  {
    public MainUserControl()
    {
      InitializeComponent();
      DataContext = new MainUserControlViewModel();
    }
  }
}