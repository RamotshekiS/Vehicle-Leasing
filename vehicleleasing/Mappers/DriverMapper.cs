using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Dtos.Driver;
using vehicleleasing.Dtos.Driver;
using vehicleleasing.Models;

namespace vehicleleasing.Mappers
{
    public static class DriverMapper
    {
        public static DriverDto ToDriverDto(this Driver driver)
        {
            return new DriverDto
            {
                Id = driver.Id,
                firstName = driver.firstName,
                lastName = driver.lastName,
                phoneNumber = driver.phoneNumber,
                email = driver.email
            };
        }

         public static Driver ToDriverFromCreateDto(this CreateDriverDto dto)
        {
            return new Driver
            {
                firstName = dto.firstName,
                lastName = dto.lastName,
                phoneNumber = dto.phoneNumber,
                email = dto.email
            };
        }
    }
}