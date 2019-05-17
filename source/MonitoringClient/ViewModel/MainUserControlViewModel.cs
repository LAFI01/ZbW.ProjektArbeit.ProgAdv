// ************************************************************************************
// FileName: MainUserControlViewModel.cs
// Author: 
// Created on: 17.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows;
  using Prism.Mvvm;

  public class MainUserControlViewModel : BindableBase
  {
    private Visibility _addLogEntryView = Visibility.Hidden;

    private Visibility _monitoringView;


    public MainUserControlViewModel()
    {
      InitialViews();
    }

    public Visibility AddLogEntryVisibility
    {
      get { return _addLogEntryView; }
      set
      {
        SetProperty(ref _addLogEntryView, value);

        //RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }


    public Visibility MonitoringVisibility
    {
      get { return _monitoringView; }
      set
      {
        SetProperty(ref _monitoringView, value);

        //RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public void InitialViews()
    {
      //AddLogEntryContent = new AddLogEntryView();
      //AddLogEntryContent.Visibility = Visibility.Collapsed;
      //MonitoringContent = new MonitoringView();
      //MonitoringContent.Visibility = Visibility.Visible;
      //MonitoringVisibility = Visibility.Visible;
      MonitoringVisibility = Visibility.Collapsed;
    }

    public void Test()
    {
    }
  }
}