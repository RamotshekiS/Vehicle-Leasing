using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vehicleleasing.Dtos.Client
{
    public class UpdateClientDto
    {
        public string companyName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}