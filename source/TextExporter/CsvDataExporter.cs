// ************************************************************************************
// FileName: CsvDataExporter.cs
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
  using PluginContracts;

  public class CsvDataExporter : IDataExportPlugin
  {
    public void Export<T>(IEnumerable data, string destinationPath)
    {
      var path = string.Concat(destinationPath, ".csv");
      using (TextWriter tw = File.CreateText(path))
      {
        foreach (var line in ToCsv.FileToCsv<T>(data))
        {
          tw.WriteLine(line);
        }
      }
    }

    public string Name
    {
      get { return GetType().Name; }
    }
  }
}