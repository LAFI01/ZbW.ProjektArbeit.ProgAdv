using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Persistence
{
  using System.Collections.ObjectModel;
  using Model;

  public interface IMonitoringRepository
  {
    void AddLogEntriy(IEntity entity);

    void ClearLogEntriy(IEntity entity);

    ObservableCollection<int> GetAllDeviceIds();

    bool ConnectionTest();

    string GetConnectionString();


    void SetConnectionString(string connString);

    ObservableCollection<string> GetAllHostname();

    ObservableCollection<IEntity> GetAllLogEntries();
  }
}
