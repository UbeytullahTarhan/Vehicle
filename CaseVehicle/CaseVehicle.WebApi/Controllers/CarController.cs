using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.IBase;
using CaseVehicle.Entity.Models;
using CaseVehicle.Interface;
using CaseVehicle.WebApi.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CaseVehicle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ApiBaseController<ICarService, Car, DtoCar>
    {
        private readonly ICarService carService;
        public CarController(ICarService Service) : base(Service)
        {
            this.carService = Service;
        }
        [HttpPost("HeadlightsOnOf")]
        public DtoCar Headlights(int id, bool Headlights)
        {
            try
            {
                
                return carService.Headlights(id, Headlights); ;
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
