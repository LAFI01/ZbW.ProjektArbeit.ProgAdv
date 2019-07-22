// ************************************************************************************
// FileName: CustomerDetail.xaml.cs
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
  ///   Interaction logic for CustomerDetail.xaml
  /// </summary>
  public partial class CustomerDetail : UserControl
  {
    public CustomerDetail()
    {
      InitializeComponent();
      DataContext = CustomerDetailViewModel.GetInstance();
    }
  }
}