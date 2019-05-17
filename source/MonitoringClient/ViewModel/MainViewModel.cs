// ************************************************************************************
// FileName: MainViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows;
  using System.Windows.Controls;
  using Prism.Mvvm;
  using View;

  public class MainViewModel : BindableBase
  {
    private UserControl _content;

    public MainViewModel()
    {
      Initial();
    }

    public UserControl Content
    {
      get { return _content; }

      set { SetProperty(ref _content, value); }
    }

    public void Initial()
    {
      //MainUserControlView = new AddLogEntryView();
      //MainUserControlView.Visibility = Visibility.Collapsed;
      Content = new MainUserControlView();
    }
  }
}