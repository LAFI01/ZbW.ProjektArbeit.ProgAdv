// ************************************************************************************
// FileName: AddLogEntryView.xaml.cs
// Author: 
// Created on: 12.05.2019
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
  ///   Interaction logic for AddLogEntryView.xaml
  /// </summary>
  public partial class AddLogEntryView : Window
  {
    public AddLogEntryView(string connString)
    {
      InitializeComponent();
      DataContext = new AddLogEntryViewModel(connString, this);
    }
  }
}