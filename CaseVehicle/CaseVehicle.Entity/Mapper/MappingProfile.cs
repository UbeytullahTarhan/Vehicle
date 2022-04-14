using CaseVehicle.Entity.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaseVehicle.Entity.Models;

namespace CaseVehicle.Entity.Mapper
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Boat, DtoBoat>().ReverseMap();
            CreateMap<bus, Dtobus>().ReverseMap();
            CreateMap<Car, DtoCar>().ReverseMap();
            
        }
    }
}
