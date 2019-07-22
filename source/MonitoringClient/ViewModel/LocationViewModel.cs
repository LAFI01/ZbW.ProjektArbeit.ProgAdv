// ************************************************************************************
// FileName: LocationViewModel.cs
// Author: 
// Created on: 18.06.2019
// Last modified on: 22.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.ViewModel
{
  using System.Collections.Generic;
  using System.Reflection;
  using System.Windows;
  using Model;
  using Persistence.Table;
  using Persistence.Table.Impl;
  using Prism.Commands;
  using Prism.Mvvm;

  public class LocationViewModel : BindableBase
  {
    private List<ILocation> _locations;

    public LocationViewModel(ILocationRepository locationRepository)
    {
      GoBackCommand = new DelegateCommand(OnCmdNavigateToMonitoringView);
      _locations = new List<ILocation>();
      LocationRepository = locationRepository;
    }

    public static DelegateCommand GoBackCommand { get; set; }

    public ILocationRepository LocationRepository { get; }

    public List<ILocation> Locations
    {
      get { return _locations; }
      set
      {
        SetProperty(ref _locations, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    private static LocationViewModel Instance { get; set; }

    public static LocationViewModel GetInstance()
    {
      if (Instance == null)
      {
        ILocationRepository locationRepo = new LocationRepository();
        Instance = new LocationViewModel(locationRepo);
      }

      return Instance;
    }

    public void LoadLocationTree()
    {
      Locations = LocationRepository.GetLocationsHierarchical();
    }

    private void OnCmdNavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.LocationVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }
  }
}