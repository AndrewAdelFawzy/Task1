using Microsoft.AspNetCore.Mvc.Rendering;
namespace Task1.Core.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(int id);
        Task<IList<Client>> GetAllClientsAsync();
        Task AddClientAsync(Client client);
        Task DeleteClientAsync(Client client);
        Task<Client> GetClientWithProductsByIdAsync(int id);
        Task UpdateClientAsync(Client client);
        List<SelectListItem> GetClientClasses(ClientClass selectedClass);
        List<SelectListItem> GetClientStates(ClientState selectedState);

    }
}
