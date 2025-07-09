using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Models;

namespace vehicleleasing.Interfaces
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllAsync();
        Task<Branch?> GetByIdAsync(int id);
        Task<Branch> CreateAsync(Branch branch);
        Task UpdateAsync(Branch branch);
        Task<Branch?> DeleteAsync(int id);
    }
}