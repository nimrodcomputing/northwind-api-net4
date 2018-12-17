using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Data;

namespace Northwind.Persistence
{
    public class NorthwindRepository<TEntity> 
        where TEntity : class
    {
        protected readonly NorthwindDb Db;
        protected readonly DbSet<TEntity> DbSet;

        public NorthwindRepository(NorthwindDb db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return DbSet;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();
            return entity;
        }
    }
}