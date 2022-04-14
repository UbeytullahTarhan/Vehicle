using CaseVehicle.Bll.Base;
using CaseVehicle.Dal.Abstract;
using CaseVehicle.Dal.Concrete.Entityframework.Repository;
using CaseVehicle.Entity.Dto;
using CaseVehicle.Entity.Models;
using CaseVehicle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CaseVehicle.Bll
{
    public class CarManager : BllBase<Car, DtoCar>, ICarService
    {

        private readonly ICarRepository carRepository;
        public CarManager(IServiceProvider service) : base(service)
        {
            carRepository = service.GetService<ICarRepository>();
        }

        public DtoCar Headlights(int id, bool Headlights)
        {
            try
            {
                var entity = carRepository.Headlights(id, Headlights);
                var t = ObjectMapper.Mapper.Map<Car, DtoCar>(entity);
                Save();

                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
