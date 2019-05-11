// ************************************************************************************
// FileName: StartView.xaml.cs
// Author: 
// Created on: 11.05.2019
// Last modified on: 11.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.View
{
  using System.Windows;

  /// <summary>
  ///   Interaction logic for StartView.xaml
  /// </summary>
  public partial class StartView : Window
  {
    public StartView()
    {
      InitializeComponent();
    }

    private void BtnNext_Click(object sender, RoutedEventArgs e)
    {
      MonitoringView monitoringView = new MonitoringView(connStringField.Text);
      monitoringView.Show();
      this.Close();
    }
  }
}