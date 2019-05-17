// ************************************************************************************
// FileName: AddLogEntryView1.xaml.cs
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
  using System.Windows.Controls;
  using ViewModel;

  /// <summary>
  ///   Interaction logic for AddLogEntryView1.xaml
  /// </summary>
  public partial class AddLogEntryView1 : UserControl
  {
    public AddLogEntryView1()
    {
      InitializeComponent();
      DataContext = new AddLogEntryViewModel();
    }
  }
}