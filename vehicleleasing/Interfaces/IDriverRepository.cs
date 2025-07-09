using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Models;

namespace vehicleleasing.Interfaces
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAllAsync();
        Task<Driver?> GetByIdAsync(int id);
        Task<Driver> CreateDriver(Driver driver);
        Task<Driver> UpdateDriver(Driver driver);
        Task<Driver?> DeleteAsync(int id);

    }
}