using CaseVehicle.Bll.Base;
using CaseVehicle.Dal.Abstract;
using CaseVehicle.Entity.Base;
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
   public class BuseManager : BllBase<bus, Dtobus>, IBusService
    {
        
        public BuseManager(IServiceProvider service) : base(service)
        {
            
        }
    }
}
