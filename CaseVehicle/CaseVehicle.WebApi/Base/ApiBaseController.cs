using CaseVehicle.Entity.Base;
using CaseVehicle.Entity.IBase;
using CaseVehicle.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CaseVehicle.WebApi.Base
{
  

        [Route("api/[controller]")]
        [ApiController]
        
        public class ApiBaseController<TInterface, T, TDto> : ControllerBase where TInterface : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
        {
            private readonly TInterface service;

            public ApiBaseController(TInterface service)
            {
                this.service = service;

            }

            [HttpGet("Find")]
            public IResponse<TDto> Find(int id)
            {
                try
                {
                    var entity = service.Find(id);

                    return entity;
                }
                catch (Exception ex)
                {
                    return new Response<TDto>
                    {
                        Message = $"Error:{ex.Message}",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Data = null
                    };
                }
            }

            [HttpGet("GetAllByColor")]
            public IResponse<List<TDto>> GetAllByColor(string color)
            {
                try
                {
                    return service.GetAllByColor(color);
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


        [HttpPost("Add")]
        public IResponse<TDto> Add(TDto item)
        {
            try
            {
                return service.Add(item);
                /*if(item is not null)
                {
                     service.Add(item);
                     return new Response<TDto>
                    {
                        Message="Success",
                        StatusCode=StatusCodes.Status201Created,
                        Data=item
                    };
                } else
                {
                    return new Response<TDto>
                    {
                        Message = "Error",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Data = null
                    };
                }*/

            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    Message = $"Error: {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        

        [HttpDelete("Delete/{id}")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                service.DeleteById(id);
                return new Response<bool>
                {
                    Message = "Data has been deleted successfully.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true
                };

            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Message = $"Error: {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = false
                };
            }
        }

        [HttpPost("StartStopEngine")]
        public TDto Update(int id,bool engine)
        {
            try
            {
                return service.Update(id,engine);
                /*if(item is not null)
                {
                     service.Add(item);
                     return new Response<TDto>
                    {
                        Message="Success",
                        StatusCode=StatusCodes.Status201Created,
                        Data=item
                    };
                } else
                {
                    return new Response<TDto>
                    {
                        Message = "Error",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Data = null
                    };
                }*/

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    }

