using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace vehicleleasing.Views.ReportsView
{
    public class SupplierReport : PageModel
    {
        private readonly ILogger<SupplierReport> _logger;

        public SupplierReport(ILogger<SupplierReport> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}