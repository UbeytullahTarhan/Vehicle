using CaseVehicle.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace CaseVehicle.Entity.Models
{
    public partial class bus:EntityBase
    {
        public int BuseId { get; set; }
        
        public bool Headlights { get; set; }
        
    }
}
