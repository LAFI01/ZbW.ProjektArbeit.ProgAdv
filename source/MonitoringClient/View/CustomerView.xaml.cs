// ************************************************************************************
// FileName: CustomerView.xaml.cs
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
  ///   Interaction logic for CustomerView.xaml
  /// </summary>
  public partial class CustomerView : UserControl
  {
    public CustomerView()
    {
      InitializeComponent();
      DataContext = CustomerViewModel.GetInstance();
    }
  }
}