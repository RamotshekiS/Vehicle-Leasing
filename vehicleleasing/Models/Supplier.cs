using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string contactPerson {get; set; }
        public string email { get; set; }
        public string contact { get; set; }

        //One to Many: One supplier can supply many Vehicles
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}

