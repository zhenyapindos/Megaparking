using Parking.Model;

namespace Parking.Interfaces;

public interface IClientDbService
{
    public Task<List<Client>> GetAllClients();
    public Task<Client> AddClient(Client client);
    public Task<Client> ChangeClientInfo(int id, Client client);
    public Task<Client> DeleteClient(int id);
}