using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Persistence.Table
{
  using Model;

  public interface IDeviceRepository
  {
    void SetConnectionString(string connString);

    List<int> GetDeviceIds();
    List<string> GetDeviceHostname();
       List<IDevice> GetDevices();
  }
}
