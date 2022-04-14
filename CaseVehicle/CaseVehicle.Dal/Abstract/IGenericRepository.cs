using CaseVehicle.Entity.Base;
using CaseVehicle.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Dal.Abstract
{
  public  interface IGenericRepository<T> where T:EntityBase
    {
        T Add(T entity);
        T Update(int id ,bool engine);//
        T Find(int id);
        List<T> GetAll();
        IQueryable<T> GetAllByColor(string color);
        bool Delete(int id);
        bool Delete(T entity);
    }
}
