// ************************************************************************************
// FileName: PluginLoader.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 22.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.PluginLoader
{
  using System;
  using System.Collections;
  using System.ComponentModel;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  using System.Security;
  using PluginContracts;
  using Syroot.Windows.IO;
  using Utilities.Impl;

  public static class PluginLoader
  {
    public static bool ExportFile<T>(IEnumerable data, string fileName, DataExporter dataExporter)
    {
      var files = Directory.GetFiles(@"..\..\..\..\source\MonitoringClient\bin\Debug\plugins",
        "*.dll");
      foreach (var file in files.Select(Path.GetFullPath))
      {
        try
        {
          Assembly assembly = Assembly.LoadFile(file);
          foreach (Type t in assembly.GetTypes().Where(t =>
            t != typeof(IDataExportPlugin) && typeof(IDataExportPlugin).IsAssignableFrom(t)))
          {
            IDataExportPlugin plugin = (IDataExportPlugin) Activator.CreateInstance(t);
            if (plugin.Name.Equals(dataExporter.ToString()))
            {
              var downloadPath = new KnownFolder(KnownFolderType.Downloads).Path;
              var destinationPath = string.Concat(downloadPath, @"\", fileName);
              plugin.Export<T>(data, destinationPath);

              return true;
            }
          }
        }
        catch (Win32Exception win32Exception)
        {
          throw win32Exception;
        }
        catch (ArgumentException argumentException)
        {
          throw argumentException;
        }
        catch (FileNotFoundException fileNotFoundException)
        {
          throw fileNotFoundException;
        }
        catch (PathTooLongException pathTooLongException)
        {
          throw pathTooLongException;
        }
        catch (BadImageFormatException badImageFormatException)
        {
          throw badImageFormatException;
        }
        catch (SecurityException securityException)
        {
          throw securityException;
        }
      }

      return false;
    }
  }
}