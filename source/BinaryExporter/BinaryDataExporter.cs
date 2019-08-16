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
  using System;
  using System.Collections;
  using PluginContracts;

  public class BinaryDataExporter : IDataExportPlugin
  {
    public void Export(IEnumerable data, string destinationPath)
    {
      throw new NotImplementedException();
    }

    public string Name
    {
      get { throw new NotImplementedException(); }
    }
  }
}