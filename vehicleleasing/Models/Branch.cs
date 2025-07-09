using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string branchName { get; set; }
        public string location { get; set; }

        //One to Many: One Branch can have many Vehicles allocated
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }
}