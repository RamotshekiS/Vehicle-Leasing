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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _context;

        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier?> DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            if (supplier == null)
            {
                return null;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return supplier;

        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.Include(s => s.Vehicles).ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers.Include(s => s.Vehicles).FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task UpdateAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}