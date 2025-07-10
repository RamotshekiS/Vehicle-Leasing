using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicleleasing.Dtos.Vehicle;
using vehicleleasing.Interfaces;
using vehicleleasing.Mappers;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            var vehicleDto = vehicles.Select(v => v.ToVehicleDto());
            return Ok(vehicleDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicles = await _vehicleRepository.GetByIdAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return Ok(vehicles.ToVehicleDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDto vehicleDto)
        {
            var vehicle = vehicleDto.ToVehicleFromCreateDto();
            await _vehicleRepository.CreateAsync(vehicle);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.vehicleId }, vehicle.ToVehicleDto());
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicle = await _vehicleRepository.deleteAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}