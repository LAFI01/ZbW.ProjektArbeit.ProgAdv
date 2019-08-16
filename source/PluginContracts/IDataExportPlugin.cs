// ************************************************************************************
// FileName: IDataExportPlugin.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 16.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace PluginContracts
{
  using System.Collections;

  public interface IDataExportPlugin
  {
    string Name { get; }

    void Export(IEnumerable data, string destinationPath);
  }
}