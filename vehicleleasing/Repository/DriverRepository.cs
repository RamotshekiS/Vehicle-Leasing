using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vehicleleasing.Data;
using vehicleleasing.Interfaces;
using vehicleleasing.Models;

namespace vehicleleasing.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationDBContext _context;

        public DriverRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Driver> CreateAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<Driver?> DeleteAsync(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);

            if (driver == null)
            {
                return null;
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver?> GetByIdAsync(int id)
        {
            return await _context.Drivers.Include(d => d.Vehicles).FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task<Driver> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}