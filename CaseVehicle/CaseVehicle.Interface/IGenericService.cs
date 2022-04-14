using CaseVehicle.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Interface
{
    public  interface IGenericService<T,TDto> where T:IEntityBase where TDto:IDtoBase
    {
        IResponse<List<TDto>> GetAll();
        IResponse<List<TDto>> GetAllByColor(string color);
        IResponse<TDto> Find(int id);
        IQueryable<T> GetIQueryable();
        IResponse<TDto> Add(TDto item, bool saveChanges = true);
        Task<TDto> AddAsync(TDto item);
        TDto Update(int id,bool engine);//
        Task<TDto> UpdateAsync(TDto item);
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(TDto item);
        Task<bool> DeleteAsync(TDto item);
        void Save();
    }
}
