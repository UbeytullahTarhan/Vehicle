using CaseVehicle.Dal.Abstract;
using CaseVehicle.Dal.Concrete.Entityframework.Repository;
using CaseVehicle.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Dal.Concrete.Entityframework.Repository
{
   public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected DbContext context;
        protected DbSet<T> dbset;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();
        }
        public T Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            dbset.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));
        }

        public bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }
            return dbset.Remove(entity) != null;
        }

        public T Find(int id)
        {
            return dbset.Find(id);
        }

        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public IQueryable<T> GetAllByColor(string color)
        {
            return dbset.Where(a=> a.Color==color);
        }

        public T Update(int id,bool engine)
        {
            
            var entity=dbset.Find(id);
            entity.Engine = engine;
            dbset.Update(entity);

            return entity;
        }
    }
}
