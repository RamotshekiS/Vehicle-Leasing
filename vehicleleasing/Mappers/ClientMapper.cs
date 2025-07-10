using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Dtos.Client;
using vehicleleasing.Dtos.Client;
using vehicleleasing.Models;

namespace vehicleleasing.Mappers
{
    public static class ClientMapper
    {
        public static ClientDto ToClientDto(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                companyName = client.companyName,
                email = client.email,
                phone = client.phone
            };
        }

        public static Client ToClientFromCreateDto(this CreateClientDto dto)
        {
            return new Client
            {
                companyName = dto.companyName,
                email = dto.email,
                phone = dto.phone
            };
        }
    }
}