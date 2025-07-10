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
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> DeleteAsync(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return null;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c => c.Vehicles).ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.Include(c => c.Vehicles)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Client> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}