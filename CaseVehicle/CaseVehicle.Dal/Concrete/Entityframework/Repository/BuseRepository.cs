using CaseVehicle.Dal.Abstract;
using CaseVehicle.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Dal.Concrete.Entityframework.Repository
{
   public class BuseRepository:GenericRepository<bus>, IBuseRepository
    {
        public BuseRepository(DbContext context) : base(context)
        {
                
        }
    }
}
