using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicleleasing.Dtos.Branch;
using vehicleleasing.Interfaces;
using vehicleleasing.Mappers;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/branch")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;
        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchRepository.GetAllAsync();
            var branchDto = branches.Select(b => b.ToBranchDto());
            return Ok(branchDto);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var branch = await _branchRepository.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch.ToBranchDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBranchDto branchDto)
        {
            var branch = branchDto.ToBranchFromCreateDto();
            await _branchRepository.CreateAsync(branch);
            return CreatedAtAction(nameof(GetById), new { id = branch.Id }, branch.ToBranchDto());
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var branch = await _branchRepository.DeleteAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}