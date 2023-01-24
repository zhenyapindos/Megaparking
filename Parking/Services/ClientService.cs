using Microsoft.EntityFrameworkCore;
using Parking.Context;
using Parking.Interfaces;
using Parking.Model;
using Parking.Requests;

namespace Parking.Services;

public class ClientService : IClientDbService
{
    private readonly ParkingContext _parkingContext;

    public ClientService(ParkingContext parkingContext)
    {
        _parkingContext = parkingContext;
    }

    public async Task<List<Client>> GetAllClients()
    {
        return await _parkingContext.Clients.ToListAsync();
    }

    public async Task<Client> AddClient(Client client)
    {
        var newClient = new Client
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Budget = client.Budget,
            PhoneNumber = client.PhoneNumber,
        };

        await _parkingContext.Clients.AddAsync(newClient);
        await _parkingContext.SaveChangesAsync();

        return newClient;
    }

    public async Task<Client> ChangeClientInfo(int id, Client newClientInfo)
    {
        var resultClient = _parkingContext.Clients.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException();

        resultClient.FirstName = newClientInfo.FirstName;
        resultClient.LastName = newClientInfo.LastName;
        resultClient.PhoneNumber = newClientInfo.PhoneNumber;

        await _parkingContext.SaveChangesAsync();

        return resultClient;
    }

    public async Task<Client> DeleteClient(int id)
    {
        var client = _parkingContext.Clients.FirstOrDefault(x => x.Id == id) ?? throw new AggregateException();

        _parkingContext.Clients.Remove(client);

        await _parkingContext.SaveChangesAsync();

        return client;
    }
}