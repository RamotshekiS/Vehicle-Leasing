using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleleasing.Data;
using vehicleleasing.ViewModels;

namespace vehicleleasing.Controllers
{
    public class ReportsViewController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ReportsViewController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SupplierReport()
       {
            var data = await _context.Vehicles
                .Include(v => v.Supplier)
                .GroupBy(v => new { v.Supplier.name, v.manufacturer })
                .Select(g => new ManufactureReportViewModel
                {
                    GroupName = g.Key.name,
                    Manufacture = g.Key.manufacturer,
                    Count = g.Count()
               })
                .ToListAsync();

            return View(data); // Pass data to Razor view
       }
    }
}