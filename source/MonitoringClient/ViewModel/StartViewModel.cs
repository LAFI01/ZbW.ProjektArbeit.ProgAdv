// ************************************************************************************
// FileName: StartViewModel.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
  using Utilities;
  using View;

  public class StartViewModel : BindableBase
  {
    private readonly StartView _startView;

    public StartViewModel(StartView startView)
    {
      _startView = startView;
      CreateClickCommand();
    }

    public ICommand NextCommand { get; set; }

    public void NextExecute()
    {
      MonitoringView monitoringView = new MonitoringView(_startView.connStringField.Text);
      monitoringView.Show();
      _startView.Close();
    }

    protected void CreateClickCommand()
    {
      NextCommand = new RelayCommand(NextExecute, CheckConnString);
    }

    private bool CheckConnString()
    {
      return true;
    }
  }
}