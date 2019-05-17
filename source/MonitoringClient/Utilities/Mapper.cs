// ************************************************************************************
// FileName: Mapper.cs
// Author: 
// Created on: 17.05.2019
// Last modified on: 17.05.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Utilities
{
  public static class Mapper
  {
    public static int MapSeverityToInt(string severity)
    {
      var status = 0;
      switch (severity)
      {
        case "Error":
          status = 1;

          break;
        case "Warning":
          status = 2;

          break;
        case "Critical":
          status = 3;

          break;
        case "Low":
          status = 4;

          break;
      }

      return status;
    }

    public static string MapSeverityToString(int num)
    {
      var status = "";
      switch (num)
      {
        case 1:
          status = "Error";

          break;
        case 2:
          status = "Warning";

          break;
        case 3:
          status = "Critical";

          break;
        case 4:
          status = "Low";

          break;
      }

      return status;
    }
  }
}