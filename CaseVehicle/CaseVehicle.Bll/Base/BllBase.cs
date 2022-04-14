using CaseVehicle.Dal.Abstract;
using CaseVehicle.Entity.Base;
using CaseVehicle.Entity.IBase;
using CaseVehicle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace CaseVehicle.Bll.Base
{
   public class BllBase<T,TDto>: IGenericService<T,TDto> where T : EntityBase where TDto : DtoBase
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        
        public BllBase(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
            this.service = service;
        }

        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {
                var resolvedResult = "";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<T>(item));
                resolvedResult = String.Join(',', TResult.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(TResult) ?? ""} - "));

                if (saveChanges)
                    Save();

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succuess",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(TResult)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<TDto> AddAsync(TDto item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TDto item)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);

                if (saveChanges) Save();

                return new Response<bool>
                {
                    Message = "Succuess",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = false
                };
            }
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            try
            {
                var entity = repository.Find(id);
                var t = ObjectMapper.Mapper.Map<T, TDto>(entity);

                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(entity)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAllByColor(string color)
        {
            try
            {
                List<T> list = repository.GetAllByColor(color).ToList();
                var dtoList = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                var response = new Response<List<TDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = dtoList
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public IQueryable<T> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public TDto Update(int id,bool engine)
        {
            try
            {
                var entity = repository.Update(id,engine);
                var t = ObjectMapper.Mapper.Map<T, TDto>(entity);
                Save();
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<TDto> UpdateAsync(TDto item)
        {
            throw new NotImplementedException();
        }
        
    }
}
