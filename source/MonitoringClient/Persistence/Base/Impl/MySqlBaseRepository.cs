// ************************************************************************************
// FileName: MySqlBaseRepository.cs
// Author: 
// Created on: 09.06.2019
// Last modified on: 07.07.2019
// Copy Right: JELA Rocks
// ------------------------------------------------------------------------------------
// Description: 
// ------------------------------------------------------------------------------------
// ************************************************************************************
namespace MonitoringClient.Persistence.Base.Impl
{
  using System;
  using System.Diagnostics;
  using System.Linq;
  using System.Linq.Expressions;
  using DbDtos;
  using LinqToDB;
  using LinqToDB.Data;

  public abstract class MySqlBaseRepository<TDto, TId> : DataConnection, IRepositoryBase<TDto> where TDto : DtoBase<TId>
  {
    protected const string RepositoryName = "inventarisierungsloesunglfi";

    protected MySqlBaseRepository() : base(RepositoryName)
    {
    }


    public void Add(TDto entity)
    {
      using (DataContext ctx = new DataContext(RepositoryName))
      {
        ctx.Insert(entity);
      }
    }

    public long Count(Expression<Func<TDto, bool>> whereClause)
    {
      using (DataContext db = new DataContext(RepositoryName))
      {
        var entities = db.GetTable<TDto>().Where(whereClause);

        return entities.Count();
      }
    }

    public long Count()
    {
      var count = GetAll().ToList().Count;

      return count;
    }

    public void Delete(TDto entity)
    {
      using (DataContext ctx = new DataContext(RepositoryName))
      {
        TDto toDeleteEntry = GetAll(e => e.Id.Equals(entity.Id)).FirstOrDefault();
        if (toDeleteEntry != null)
        {
          ctx.Delete(toDeleteEntry);
        }
      }
    }

    public void ExecuteStoreProcedur(string storeProcedureName, DataParameter[] dataParameters)
    {
      using (DataConnection db = new DataConnection(RepositoryName))
      {
        db.QueryProc<TDto>(storeProcedureName, dataParameters);
      }
    }

    public IQueryable<TDto> GetAll(Expression<Func<TDto, bool>> whereClause)
    {
      var entities = Enumerable.Empty<TDto>().AsQueryable();
      using (DataContext db = new DataContext(RepositoryName))
      {
        entities = db.GetTable<TDto>().Where(whereClause);

        return entities;
      }
    }


    public IQueryable<TDto> GetAll()
    {
      using (DataContext ctx = new DataContext(RepositoryName))
      {
        var entries = ctx.GetTable<TDto>();

        return entries;
      }
    }


    public TDto GetSingle<P>(P pkValue)
    {
      using (DataContext ctx = new DataContext(RepositoryName))
      {
        TDto entry = ctx.GetTable<TDto>().FirstOrDefault(e => e.Id.Equals(pkValue));

        return entry;
      }
    }

    public IQueryable<TDto> Query(Expression<Func<TDto, bool>> whereClause)
    {
      using (DataContext db = new DataContext(RepositoryName))
      {
        var entities = db.GetTable<TDto>().Where(whereClause);

        return entities;
      }
    }


    public void Update(TDto entity)
    {
      using (DataContext ctx = new DataContext(RepositoryName))
      {
        ctx.Update(entity);
      }
    }


    public bool ConnectionTest()
    {
      var isConnected = false;
      try
      {
        using (DataContext db = new DataContext(RepositoryName))
        {
          var entities = db.GetTable<DeviceDto>();
          isConnected = entities.Any();
        }
      }
      catch (Exception ex)
      {
        Debug.Print(string.Format($"Conncetion failed: {ex.Message}"));
      }

      return isConnected;
    }
  }
}