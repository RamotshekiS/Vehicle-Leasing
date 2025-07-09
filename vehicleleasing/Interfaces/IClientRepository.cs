using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Models;

namespace vehicleleasing.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client> CreateClient(Client client);
        Task<Client> UpdateClient(Client client);
        Task<Client?> DeleteAsync(int id);
    }
}