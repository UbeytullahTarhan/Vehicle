using CaseVehicle.Entity.Dto;
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
    public class BuseController : ApiBaseController<IBusService, bus, Dtobus>
    {
        private readonly IBusService buseService;
        public BuseController(IBusService Service) : base(Service)
        {
            this.buseService = Service;
        }
    }
}
