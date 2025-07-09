using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        //One to Many: One client can lease many Vehicles
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }
}