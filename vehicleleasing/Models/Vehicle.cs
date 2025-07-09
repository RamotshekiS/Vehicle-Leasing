using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Models
{
    public class Vehicle
    {
        public int vehicleId { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public int year { get; set; }

        public int SupplierId { get; set; }
        public int BranchId { get; set; }
        public int ClientId { get; set; }
        public int DriverId { get; set; }

    // Many-to-One: Many Vehicles can be from one Supplier
       public Supplier Supplier { get; set; }
       public Branch Branch { get; set; }
       public Client Client { get; set; }
       public Driver Driver { get; set; }
    }
}

