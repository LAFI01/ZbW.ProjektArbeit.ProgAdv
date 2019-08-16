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
  using System;
  using System.Collections;
  using PluginContracts;

  public class JsonDataExporter : IDataExportPlugin
  {
    public void Export(IEnumerable data, string destinationPath)
    {
      throw new NotImplementedException();
    }

    public string Name { get; }
  }
}