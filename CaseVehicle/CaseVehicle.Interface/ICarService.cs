using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Interface
{
   public interface ICarService:IGenericService<Car,DtoCar>
    {
        DtoCar Headlights(int id, bool Headlights);
    }
}
