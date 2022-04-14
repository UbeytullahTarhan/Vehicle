using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Dal.Abstract
{
   public interface ICarRepository
    {
       public Car Headlights(int id, bool Headlights);
    }
}
