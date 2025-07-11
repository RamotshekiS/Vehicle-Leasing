using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using vehicleleasing.Data;
using vehicleleasing.Interfaces;
using vehicleleasing.Models;

namespace vehicleleasing.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDBContext _context;

        public BranchRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Branch> CreateAsync(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch?> DeleteAsync(int id)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(b => b.Id == id);

            if (branch == null)
            {
                return null;
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
            return await _context.Branches.Include(b => b.Vehicles).FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task UpdateAsync(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}