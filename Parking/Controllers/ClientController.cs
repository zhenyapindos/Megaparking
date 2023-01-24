using Microsoft.AspNetCore.Mvc;
using Parking.Context;
using Parking.Dto;
using Parking.Interfaces;
using Parking.Model;

namespace Parking.Controllers;

public class ClientController : Controller
{
    private readonly IClientDbService _service;
    private readonly ParkingContext _context;
    
    public ClientController(IClientDbService service, ParkingContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet("GetAllClients")]
    [ProducesResponseType(typeof(IEnumerable<ClientDto>), 200)]
    [ProducesResponseType(typeof(List<Task>), 200)]
    public async Task<IActionResult> GetAllClients()
    {
        return Ok(await _service.GetAllClients());
    }

    [HttpPost("AddClient")]
    [ProducesResponseType(typeof(ClientDto), 200)]
    [ProducesResponseType(typeof(ClientDto), 200)]
    public async Task<IActionResult> AddClient([FromBody] Client client)
    {
        var newClient = new Client
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Budget = client.Budget,
            PhoneNumber = client.PhoneNumber,
        };
        
        await _context.Clients.AddAsync(newClient);
        await _context.SaveChangesAsync();
        
        var resultClient = new ClientDto()
        {
            Id = newClient.Id,
            FirstName = newClient.FirstName,
            LastName = newClient.LastName,
            Budget = newClient.Budget,
            PhoneNumber = newClient.PhoneNumber
        };

        return Ok(resultClient);
    }

    [HttpPut("ChangeClientInfo")]
    [ProducesResponseType(typeof(ClientDto), 200)]
    [ProducesResponseType(typeof(object), 404)]
    [ProducesResponseType(typeof(object), 400)]
    public async Task<IActionResult> ChangeClientInfo(int id, [FromBody] Client client)
    {
        return Ok(await _service.ChangeClientInfo(id, client));
    }
    
    [HttpDelete("DeleteClient")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(object), 404)]
    public async Task<IActionResult> DeleteClient(int id)
    {
        return Ok(await _service.DeleteClient(id));
    }
}