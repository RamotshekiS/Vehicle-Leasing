using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Dtos.VehicleDto
{
    public class CreateVehicleDto
    {
        public String manufacture { get; set; }
        public String model { get; set; }
        public int year { get; set; }
        public int SupplierId { get; set; }
        public int BranchId { get; set; }
        public int ClientId { get; set; }
        public int DriverId { get; set; }
    }
}