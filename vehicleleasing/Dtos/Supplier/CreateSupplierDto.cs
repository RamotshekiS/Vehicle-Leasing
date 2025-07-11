using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Dtos.Supplier
{
    public class CreateSupplierDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string contactPerson {get; set; }
        public string contact { get; set; }
        
    }
}