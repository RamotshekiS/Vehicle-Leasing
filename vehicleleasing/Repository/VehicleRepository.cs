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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDBContext _context;

        public VehicleRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle?> deleteAsync(int id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.vehicleId == id);

            if (vehicle == null)
            {
                return null;
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;


        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(i => i.vehicleId == id);
        }

        public Task UpdateAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}