// ************************************************************************************
// FileName: AddLogEntryView.xaml.cs
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
  using ViewModel;

  /// <summary>
  ///   Interaction logic for AddLogEntryView.xaml
  /// </summary>
  public partial class AddLogEntryView : UserControl
  {
    public AddLogEntryView()
    {
      InitializeComponent();
      DataContext = new AddLogEntryViewModel();
    }
  }
}