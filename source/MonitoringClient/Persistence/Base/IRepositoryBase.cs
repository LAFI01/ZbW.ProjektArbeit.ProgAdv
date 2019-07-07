// ************************************************************************************
// FileName: IRepositoryBase.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Base
{
  using System;
  using System.Linq;
  using System.Linq.Expressions;
  using LinqToDB.Data;

  public interface IRepositoryBase<M>
  {
    /// <summary>
    ///   Fügt das Model-Objekt zur Datenbank hinzu (Insert)
    /// </summary>
    /// <param name="entity">zu speicherndes Model-Object</param>
    void Add(M entity);

    /// <summary>
    ///   Zählt in der Datenbank die Anzahl Model-Objekte vom Typ M, die der
    ///   Where-Bedingung entsprechen
    /// </summary>
    /// <param name="whereClause">
    ///   WhereBedingung als string
    ///   z.B. "NetPrice > @netPrice and Active = @active and Description like @desc
    /// </param>
    /// <returns></returns>
    long Count(Expression<Func<M, bool>> whereClause);

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
    ///   Hier wird ein Store Procedure ausgeführt. Es muss eine Liste von Daten Parameter mitgegeben werden, sowie
    ///   dazugehörigen
    ///   Store Procedure name.
    /// </summary>
    /// <param name="storeProcedureName">
    ///   Name des Store Procedure
    /// </param>
    /// <param name="dataParameters">
    ///   Parameter-Werte für das Store Procedure
    /// </param>
    void ExecuteStoreProcedur(string storeProcedureName, DataParameter[] dataParameters);

    /// <summary>
    ///   Liefert ein Liste von Entries, welche der where clause entsprechen
    /// </summary>
    /// <param name="whereClause">WhereClausey</param>
    /// <returns>gefundenes Model-Objekt, ansonsten null</returns>
    IQueryable<M> GetAll(Expression<Func<M, bool>> whereClause);

    /// <summary>
    ///   Gibt eine Liste aller in der DB vorhandenen Model-Objekte vom Typ M zurück
    /// </summary>
    /// <returns></returns>
    IQueryable<M> GetAll();

    /// <summary>
    ///   Liefert ein einzelnes Model-Objekt vom Typ M zurück,
    ///   welches anhand dem übergebenen PrimaryKey geladen wird.
    /// </summary>
    /// <typeparam name="P">Type des PrimaryKey</typeparam>
    /// <param name="pkValue">Wert des PrimaryKey</param>
    /// <returns>gefundenes Model-Objekt, ansonsten null</returns>
    M GetSingle<P>(P pkValue);

    /// <summary>
    ///   Liefert ein Liste von Entries, welche der where clause entsprechen
    /// </summary>
    /// <param name="whereClause">WhereClausey</param>
    /// <returns>gefundenes Model-Objekt, ansonsten null</returns>
    IQueryable<M> Query(Expression<Func<M, bool>> whereClause);

    /// <summary>
    ///   Aktualisiert das Model-Objekt in der Datenbank hinzu (Update)
    /// </summary>
    /// <param name="entity">zu aktualisierendes Model-Object</param>
    void Update(M entity);
  }
}