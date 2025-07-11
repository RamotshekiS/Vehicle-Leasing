using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleleasing.Data;
using vehicleleasing.Dtos.ManufactureReport;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ReportsController(ApplicationDBContext context)
        {
            _context = context;
        }

        //Vehicles per supplier
        [HttpGet("supplier")]
        public async Task<IActionResult> GetVehiclesPerSupplier()
        {
            var data = await _context.Vehicles
            .Include(v => v.Supplier).GroupBy(v => new
            {
                v.Supplier.name,
                v.manufacturer
            }).Select(g => new ManufactureReportDto
            {
                GroupName = g.Key.name,
                Manufacture = g.Key.manufacturer,
                Count = g.Count()
            }).ToListAsync();
            return Ok(data);
        }

        [HttpGet("branch")]
        public async Task<IActionResult> GetVehiclesPerBranch()
        {
            var data = await _context.Vehicles
                .Include(v => v.Branch)
                .GroupBy(v => new { v.Branch.branchName, v.manufacturer })
                .Select(g => new ManufactureReportDto
                {
                    GroupName = g.Key.branchName,
                    Manufacture = g.Key.manufacturer,
                    Count = g.Count()
                }).ToListAsync();
            return Ok(data);
        }

        [HttpGet("client")]
        public async Task<IActionResult> GetVehiclesPerClient()
        {
            var data = await _context.Vehicles
                .Include(v => v.Client)
                .GroupBy(v => new { v.Client.companyName, v.manufacturer })
                .Select(g => new ManufactureReportDto
                {
                    GroupName = g.Key.companyName,
                    Manufacture = g.Key.manufacturer,
                    Count = g.Count()
                }).ToListAsync();
            return Ok(data);
        }

    }
}