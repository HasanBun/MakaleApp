using MakaleApp.Data.Context;
using MakaleApp.Data.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaleApp.Data.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly MakaleDbContext Context;
        public DbSet<TEntity> EntitySet { get; set; }

        protected BaseRepository(MakaleDbContext context)
        {
            Context = context;
            EntitySet = context.Set<TEntity>();
        }
        
        public void Delete(TEntity model)
        {
            model.IsDeleted = true;
            Context.Entry(model).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void DeleteById(int Id)
        {
            Delete(GetDataById(Id));
        }

        public IQueryable<TEntity> GetAllData()
        {
            return EntitySet.Where(x => !x.IsDeleted).AsQueryable();
        }

        public TEntity GetDataById(int Id)
        {
            return EntitySet.Find(Id);
        }

        public void Insert(TEntity model)
        {
            model.CreateDate = DateTime.Now;
            EntitySet.Add(model);
            Context.SaveChanges();
        }

        public void Update(TEntity model)
        {
            model.UpdateDate = DateTime.Now;
            Context.Entry(model).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
