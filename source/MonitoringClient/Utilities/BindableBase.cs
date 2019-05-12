// ************************************************************************************
// FileName: BindableBase.cs
// Author: 
// Created on: 12.05.2019
// Last modified on: 12.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities
{
  using System.Collections.Specialized;
  using System.ComponentModel;

  public class BindableBase : INotifyPropertyChanged, INotifyCollectionChanged
  {
    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      {
        if (PropertyChanged != null)
        {
          PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
          PropertyChanged(this, args);
        }
      }
    }


    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      if (CollectionChanged != null)
      {
        CollectionChanged(this, e);
      }
    }

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}