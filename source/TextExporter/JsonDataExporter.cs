// ************************************************************************************
// FileName: JsonDataExporter.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 16.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace TextExporter
{
  using System.Collections;
  using System.IO;
  using Newtonsoft.Json;
  using PluginContracts;

  public class JsonDataExporter : IDataExportPlugin
  {
    public void Export<T>(IEnumerable data, string destinationPath)
    {
      JsonSerializer serializer = new JsonSerializer();
      var path = string.Concat(destinationPath, "JSON.txt");
      using (StreamWriter s = File.CreateText(path))
      {
        serializer.Serialize(s, data);
        s.Close();
      }
    }

    public string Name
    {
      get { return GetType().Name; }
    }
  }
}