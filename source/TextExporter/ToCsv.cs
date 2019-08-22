// ************************************************************************************
// FileName: ToCsv.cs
// Author: 
// Created on: 16.08.2019
// Last modified on: 22.08.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace TextExporter
{
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  public class ToCsv
  {
    public static IEnumerable<string> FileToCsv<T>(IEnumerable objectlist, string separator = ",", bool header = true)
    {
      var fields = typeof(T).GetFields();
      var properties = typeof(T).GetProperties();
      if (header)
      {
        yield return string.Join(separator,
          fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());
      }

      foreach (object o in objectlist)
      {
        yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
          .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
      }
    }
  }
}