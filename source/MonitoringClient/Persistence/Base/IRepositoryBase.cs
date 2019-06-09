// ************************************************************************************
// FileName: IRepositoryBase.cs
// Author: 
// Created on: 01.06.2019
// Last modified on: 09.06.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Base
{
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;
  using MySql.Data.MySqlClient;

  public interface IRepositoryBase<M>
  {
    /// <summary>
    ///   Gibt den Tabellennamen zurück, auf die sich das Repository bezieht
    /// </summary>
    string TableName { get; }

    /// <summary>
    ///   Fügt das Model-Objekt zur Datenbank hinzu (Insert)
    /// </summary>
    /// <param name="entity">zu speicherndes Model-Object</param>
    void Add(M entity);

    /// <summary>
    ///   Zählt in der Datenbank die Anzahl Model-Objekte vom Typ M, die der
    ///   Where-Bedingung entsprechen
    /// </summary>
    /// <param name="whereCondition">
    ///   WhereBedingung als string
    ///   z.B. "NetPrice > @netPrice and Active = @active and Description like @desc
    /// </param>
    /// <param name="parameterValues">
    ///   Parameter-Werte für die Wherebedingung
    ///   bspw: {{"netPrice", 10.5}, {"active", true}, {"desc", "Wolle%"}}
    /// </param>
    /// <returns></returns>
    long Count(string whereCondition, Dictionary<string, object> parameterValues);

    /// <summary>
    ///   Zählt alle Model-Objekte vom Typ M
    /// </summary>
    /// <returns></returns>
    long Count();

    /// <summary>
    ///   Löscht das Model-Objekt aus der Datenbank (Delete)
    /// </summary>
    /// <param name="entity">zu löschendes Model-Object</param>
    void Delete(M entity);

    /// <summary>
    ///   Hier wird ein Store Procedure ausgeführt. Ess muss eine Liste von Input Keys mitgegeben werden, sowie dazugehörigen
    ///   Parameter.
    /// </summary>
    /// <param name="procedureName">
    ///   Name des Store Procedure
    /// </param>
    /// <param name="mySqlParameters">
    ///   Input Parameter-Werte für das Store Procedure
    /// </param>
    /// <param name="dbTypes">
    ///   Liste von Dbtypes von den Paramter Werten
    /// </param>
    void ExecuteStoreProcedur(string procedureName, List<MySqlParameter> mySqlParameters, List<DbType> dbTypes);

    /// <summary>
    ///   Gibt eine Liste von Model-Objekten vom Typ M zurück,
    ///   die gemäss der WhereBedingung geladen wurden. Die Werte der
    ///   Where-Bedingung können als separat übergeben werden,
    ///   damit diese für PreparedStatements verwendet werden können.
    ///   (Verhinderung von SQL-Injection)
    /// </summary>
    /// <param name="whereCondition">
    ///   WhereBedingung als string
    ///   z.B. "NetPrice > @netPrice and Active = @active and Description like @desc
    /// </param>
    /// <param name="parameterValues">
    ///   Parameter-Werte für die Wherebedingung
    ///   bspw: {{"netPrice", 10.5}, {"active", true}, {"desc", "Wolle%"}}
    /// </param>
    /// <returns></returns>
    List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues);

    /// <summary>
    ///   Gibt eine Liste aller in der DB vorhandenen Model-Objekte vom Typ M zurück
    /// </summary>
    /// <returns></returns>
    List<M> GetAll();

    /// <summary>
    ///   Liefert ein einzelnes Model-Objekt vom Typ M zurück,
    ///   welches anhand dem übergebenen PrimaryKey geladen wird.
    /// </summary>
    /// <typeparam name="P">Type des PrimaryKey</typeparam>
    /// <param name="pkValue">Wert des PrimaryKey</param>
    /// <returns>gefundenes Model-Objekt, ansonsten null</returns>
    M GetSingle<P>(P pkValue);

    IQueryable<M> Query(string whereCondition, Dictionary<string, object> parameterValues);

    /// <summary>
    ///   Aktualisiert das Model-Objekt in der Datenbank hinzu (Update)
    /// </summary>
    /// <param name="entity">zu aktualisierendes Model-Object</param>
    void Update(M entity);
  }
}