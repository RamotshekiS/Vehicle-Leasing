using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vehicleleasing.Dtos.Client;
using vehicleleasing.Interfaces;
using vehicleleasing.Mappers;

namespace vehicleleasing.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientRepository.GetAllAsync();
            var clientDto = clients.Select(c => c.ToClientDto());
            return Ok(clientDto);

        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client.ToClientDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientDto clientDto)
        {
            var client = clientDto.ToClientFromCreateDto();
            await _clientRepository.CreateAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client.ToClientDto());
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var client = await _clientRepository.DeleteAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}