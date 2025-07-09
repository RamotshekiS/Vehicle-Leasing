using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Dtos.Vehicle
{
    public class VehicleDto
    {
       public int vehicleId { get; set; }
       public string manufacturer { get; set; }
       public string model { get; set; }
       public int year { get; set; }

       public string SupplierName { get; set; }
       public string BranchName { get; set; }
       public string ClientName { get; set; }
       public string DriverName { get; set; }
    }
}