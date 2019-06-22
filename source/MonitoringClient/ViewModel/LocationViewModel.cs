// ************************************************************************************
// FileName: LocationViewModel.cs
// Author: 
// Created on: 18.06.2019
// Last modified on: 18.06.2019
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
    private static LocationViewModel Instance { get; set; }

    private List<ILocation> _locations;

    public ILocationRepository LocationRepository { get; private set; }

    public LocationViewModel(ILocationRepository locationRepository)
    {
      GoBackCommand = new DelegateCommand(OnCmdGoBack);
      _locations = new List<ILocation>();
      LocationRepository = locationRepository;
    }

    public void CreateLocationTree()
    {
      LoadLocationTree();

    }

    private void LoadLocationTree()
    {
      Locations = LocationRepository.GetLocationsHierarchical();  
      //for (int i = 0; i < Locations.Count; i++)
      //{
      //  foreach (var child in Locations[i].Childs)
      //  {
      //      Locations[i].Locations.Add(child);
      //  }
      //}

    }

    private void OnCmdGoBack()
    {
      NavigateToMonitoringView();
    }

    private void NavigateToMonitoringView()
    {
      MainUserControlViewModel mainUserControl = MainUserControlViewModel.GetInstance();
      mainUserControl.LocationVisibility = Visibility.Collapsed;
      mainUserControl.AddLogEntryVisibility = Visibility.Collapsed;
      mainUserControl.MonitoringVisibility = Visibility.Visible;
    }

    public List<ILocation> Locations
    {
      get { return _locations; }
      set
      {
        SetProperty(ref _locations, value);
        RaisePropertyChanged(MethodBase.GetCurrentMethod().Name);
      }
    }

    public static DelegateCommand GoBackCommand { get; set; }


    public static LocationViewModel GetInstance()
    {
      if (Instance == null)
      {
        ILocationRepository locationRepo = new LocationRepository();
        Instance = new LocationViewModel(locationRepo);
      }

      return Instance;
    }
  }
}