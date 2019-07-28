// ************************************************************************************
// FileName: CustomerDetailView.xaml.cs
// Author: 
// Created on: 22.07.2019
// Last modified on: 22.07.2019
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
  ///   Interaction logic for CustomerDetailView.xaml
  /// </summary>
  public partial class CustomerDetailView : UserControl
  {
    public CustomerDetailView()
    {
      InitializeComponent();
      DataContext = CustomerDetailViewModel.GetInstance();
    }
  }
}