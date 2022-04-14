using CaseVehicle.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace CaseVehicle.Entity.Models
{
    public partial class Car:EntityBase
    {
        public int CarId { get; set; }
        
        public bool Headlights { get; set; }
        
    }
}
