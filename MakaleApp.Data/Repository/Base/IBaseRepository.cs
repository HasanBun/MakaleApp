using MakaleApp.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakaleApp.Data.Repository.Base
{
    public interface IBaseRepository<TEntity> 
        where TEntity : class, IBaseEntity
    {
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        void DeleteById(int Id);

        IQueryable<TEntity> GetAllData();
        TEntity GetDataById(int Id);
    }
}
