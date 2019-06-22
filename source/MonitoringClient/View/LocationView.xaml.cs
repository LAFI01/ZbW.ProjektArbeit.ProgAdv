// ************************************************************************************
// FileName: LocationView.xaml.cs
// Author: 
// Created on: 18.06.2019
// Last modified on: 18.06.2019
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
  ///   Interaction logic for LocationView.xaml
  /// </summary>
  public partial class LocationView : UserControl
  {
    public LocationView()
    {
      InitializeComponent();
      DataContext = LocationViewModel.GetInstance();
    }
  }
}