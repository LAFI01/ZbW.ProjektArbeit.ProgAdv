// ************************************************************************************
// FileName: MainUserControlView.xaml.cs
// Author: 
// Created on: 16.05.2019
// Last modified on: 26.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.View
{
  using ViewModel;

  /// <summary>
  ///   Interaction logic for MainUserControlView.xaml
  /// </summary>
  public partial class MainUserControlView
  {
    public MainUserControlView()
    {
      InitializeComponent();
      DataContext = MainUserControlViewModel.GetInstance();
    }
  }
}