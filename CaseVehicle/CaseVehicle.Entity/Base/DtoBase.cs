﻿using CaseVehicle.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseVehicle.Entity.Base
{
   public class DtoBase:IDtoBase
    {
        public string Color { get; set; }
        public bool Engine { get; set; }
    }
}
