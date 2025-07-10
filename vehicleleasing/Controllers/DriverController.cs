using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicleleasing.Dtos.Driver;
using vehicleleasing.Interfaces;
using vehicleleasing.Mappers;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/driver")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _driverRepository.GetAllAsync();
            var drivetDto = drivers.Select(d => d.ToDriverDto());
            return Ok(drivetDto);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var driver = await _driverRepository.GetByIdAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver.ToDriverDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDriverDto driverDto)
        {
            var driver = driverDto.ToDriverFromCreateDto();
            await _driverRepository.CreateAsync(driver);
            return CreatedAtAction(nameof(GetById), new { id = driver.Id }, driver.ToDriverDto());
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var driver = await _driverRepository.DeleteAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}