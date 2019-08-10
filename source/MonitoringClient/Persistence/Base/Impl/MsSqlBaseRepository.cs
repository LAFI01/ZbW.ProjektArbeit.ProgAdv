using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringClient.Persistence.Base.Impl
{
  using System.Diagnostics;
  using System.Linq.Expressions;
  using DbDtos;
  using EntityFramework;
  using LinqToDB;
  using LinqToDB.Data;

  public abstract class MsSqlBaseRepository<TDto, TId, TDbSet> : DataConnection, IRepositoryBase<TDto> where TDto : DtoBase<TId>
  {
    //protected const string RepositoryName = "inventarisierungsloesunglfi";

    protected MsSqlBaseRepository()
    {
    }

    protected abstract void E(InvDb ctx);
    public void Add(TDto entity)
    {
      using (InvDb ctx = new InvDb())
      {
        E(ctx);
        ctx.SaveChanges();
      }
    }

    public long Count(Expression<Func<TDto, bool>> whereClause)
    {
      using (DataContext db = new DataContext())
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
      using (DataContext ctx = new DataContext())
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
      using (DataConnection db = new DataConnection())
      {
        db.QueryProc<TDto>(storeProcedureName, dataParameters);
      }
    }

    public IQueryable<TDto> GetAll(Expression<Func<TDto, bool>> whereClause)
    {
      var entities = Enumerable.Empty<TDto>().AsQueryable();
      using (DataContext db = new DataContext())
      {
        entities = db.GetTable<TDto>().Where(whereClause);

        return entities;
      }
    }


    public IQueryable<TDto> GetAll()
    {
      using (DataContext ctx = new DataContext())
      {
        var entries = ctx.GetTable<TDto>();

        return entries;
      }
    }


    public TDto GetSingle<P>(P pkValue)
    {
      using (DataContext ctx = new DataContext())
      {
        TDto entry = ctx.GetTable<TDto>().FirstOrDefault(e => e.Id.Equals(pkValue));

        return entry;
      }
    }

    public IQueryable<TDto> Query(Expression<Func<TDto, bool>> whereClause)
    {
      using (DataContext db = new DataContext())
      {
        var entities = db.GetTable<TDto>().Where(whereClause);

        return entities;
      }
    }


    public void Update(TDto entity)
    {
      using (DataContext ctx = new DataContext())
      {
        ctx.Update(entity);
      }
    }


    public bool ConnectionTest()
    {
      var isConnected = false;
      try
      {
        using (DataContext db = new DataContext())
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

