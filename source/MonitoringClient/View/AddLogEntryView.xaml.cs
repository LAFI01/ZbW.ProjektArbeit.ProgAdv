// ************************************************************************************
// FileName: AddLogEntryView.xaml.cs
// Author: 
// Created on: 14.05.2019
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
  ///   Interaction logic for AddLogEntryView.xaml
  /// </summary>
  public partial class AddLogEntryView
  {
    public AddLogEntryView()
    {
      InitializeComponent();
      DataContext = AddLogEntryViewModel.GetInstance();
    }
  }
}