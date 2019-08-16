// ************************************************************************************
// FileName: BinaryDataExporter.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 16.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace BinaryExporter
{
  using System.Collections;
  using System.IO;
  using System.Runtime.Serialization;
  using System.Runtime.Serialization.Formatters.Binary;
  using PluginContracts;

  public class BinaryDataExporter : IDataExportPlugin
  {
    public void Export<T>(IEnumerable data, string destinationPath)
    {
      IFormatter f = new BinaryFormatter();
      var path = string.Concat(destinationPath, "-BinaryDataExport.txt");
      using (FileStream s = new FileStream(path, FileMode.Create))
      {
        f.Serialize(s, data);
        s.Close();
      }
    }

    public string Name
    {
      get { return GetType().Name; }
    }
  }
}