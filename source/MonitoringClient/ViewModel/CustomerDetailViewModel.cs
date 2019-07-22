// ************************************************************************************
// FileName: CustomerDetailViewModel.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 22.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Windows;
  using Prism.Mvvm;

  public class CustomerDetailViewModel : BindableBase
  {
    private static CustomerDetailViewModel Instance { get; set; }

    public static CustomerDetailViewModel GetInstance()
    {
      if (Instance == null)
      {
        //ILocationRepository locationRepo = new LocationRepository();
        Instance = new CustomerDetailViewModel();
      }

      return Instance;
    }

    private void OnCmdNavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.CustomerVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }
  }
}