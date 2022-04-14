using CaseVehicle.Bll.Base;
using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.Models;
using CaseVehicle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Bll
{
   public class BoatManager: BllBase<Boat, DtoBoat>, IBoatService
    {
        public BoatManager(IServiceProvider service) : base(service)
        {

        }
    }
}
