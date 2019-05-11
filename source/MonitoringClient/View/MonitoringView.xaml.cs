namespace MonitoringClient.View
{
  using System;
  using System.Collections.Generic;
  using System.Windows;
  using Model;
  using ViewModel;

  /// <summary>
  /// Interaction logic for MonitoringView.xaml
  /// </summary>
  public partial class MonitoringView : Window
  {
    public List<ILogEntry> LogEntriesList { get; set; }
    private MonitoringViewModel MonitoringViewModel { get; set; }
    public MonitoringView(string connString)
    {
      InitializeComponent();
      MonitoringViewModel = new MonitoringViewModel(connString);
      this.DataContext = MonitoringViewModel;

    }



    private void BtnLoad_Click(object sender, RoutedEventArgs e)
    {
      MonitoringViewModel.GetAllLogEntries();
    }

 
  }
}
