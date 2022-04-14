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
    public class BoatController: ApiBaseController<IBoatService, Boat, DtoBoat>
    {
        private readonly IBoatService boatService;
        public BoatController(IBoatService Service) : base(Service)
        {
            this.boatService = Service;
        }
    }
}
