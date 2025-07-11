using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Dtos.Vehicle;
using vehicleleasing.Dtos.Vehicle;
using vehicleleasing.Models;

namespace vehicleleasing.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDto ToVehicleDto(this Vehicle vehicle)
        {
            return new VehicleDto
            {
                vehicleId = vehicle.vehicleId,
                manufacturer = vehicle.manufacturer,
                model = vehicle.model,
                year = vehicle.year,

                // Navigation properties
                SupplierName = vehicle.Supplier?.name,
                BranchName = vehicle.Branch?.branchName,
                ClientName = vehicle.Client?.companyName,
                DriverName = vehicle.Driver?.firstName
            };
        }

        public static Vehicle ToVehicleFromCreateDto(this CreateVehicleDto vehicleDto)
        {
            return new Vehicle
            {
                manufacturer = vehicleDto.manufacture,
                model = vehicleDto.model,
                year = vehicleDto.year,
                SupplierId = vehicleDto.SupplierId,
                BranchId = vehicleDto.BranchId,
                ClientId = vehicleDto.ClientId,
                DriverId = vehicleDto.DriverId
            };
        }
        
        public static Vehicle ToVehicleFromUpdateDto(this UpdateVehicleDto dto, int vehicleId)
        {
            return new Vehicle
            {
                vehicleId = vehicleId,
                manufacturer = dto.manufacture,
                model = dto.model,
                year = dto.year,
                SupplierId = dto.SupplierId,
                BranchId = dto.BranchId,
                ClientId = dto.ClientId,
                DriverId = dto.DriverId
            };
        }
    }
}