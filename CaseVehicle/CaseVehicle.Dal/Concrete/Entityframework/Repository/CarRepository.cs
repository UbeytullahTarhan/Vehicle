using CaseVehicle.Dal.Abstract;
using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Dal.Concrete.Entityframework.Repository
{
   public class CarRepository:GenericRepository<Car>,ICarRepository
    {

        public CarRepository(DbContext context) : base(context)
        {

        }

       

        Car ICarRepository.Headlights(int id, bool Headlights)
        {
            Car car = dbset.Find(id);
            
            car.Headlights = Headlights;
            dbset.Update(car);
            
            return car;
        }
    }
}
