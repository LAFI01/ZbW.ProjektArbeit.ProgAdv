using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.PluginLoader
{
  using System.Collections;
  using System.ComponentModel;
  using System.IO;
  using System.Reflection;
  using System.Security;
  using PluginContracts;

  public class PluginLoader
  {
    public void ExportFile(IEnumerable data, string destinationPath)
    {
      var files = Directory.GetFiles(@".\plugins\", "*.dll");

      foreach (var file in files.Select(Path.GetFullPath))
      {
        try
        {
          // TODO:
          // 1) Assembly laden (siehe Klasse Assembly)
          // 2) prüfen, ob es einen Typ gibt, der das Interface IPlugin implementiert (siehe Methode Type.IsAssignableFrom())
          // 3) sofern ein Typ gefunden, soll dieser instanziiert werden (siehe Activator.CreateInstance())
          // 4) Methode Execute() ausführen

          // Ignore assemblies we can't load. They could be native, etc...
          var assembly = Assembly.LoadFile(file);
          foreach (var t in assembly.GetTypes().Where(t => t != typeof(IDataExportPlugin) && typeof(IDataExportPlugin).IsAssignableFrom(t)))
          {
            var plugin = (IDataExportPlugin)Activator.CreateInstance(t);
            plugin.Export(data, destinationPath);
          }
        }
        catch (Win32Exception)
        {
        }
        catch (ArgumentException)
        {
        }
        catch (FileNotFoundException)
        {
        }
        catch (PathTooLongException)
        {
        }
        catch (BadImageFormatException)
        {
        }
        catch (SecurityException)
        {
        }
      }
    }
  }
}
