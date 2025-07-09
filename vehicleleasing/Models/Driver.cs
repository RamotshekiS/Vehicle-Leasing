using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        //One to Many: One driver can drive many vehicles
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }
}