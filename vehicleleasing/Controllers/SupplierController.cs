using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicleleasing.Dtos.Supplier;
using vehicleleasing.Interfaces;
using vehicleleasing.Mappers;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            var supplierDto = suppliers.Select(s => s.ToSupplierDto());
            return Ok(supplierDto);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var suppliers = await _supplierRepository.GetByIdAsync(id);
            if (suppliers == null)
            {
                return null;
            }

            return Ok(suppliers.ToSupplierDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDto supplierDto)
        {
            var supplier = supplierDto.ToSupplierFromCreateDto();
            await _supplierRepository.CreateAsync(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier.ToSupplierDto());
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var supplier = await _supplierRepository.DeleteAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}