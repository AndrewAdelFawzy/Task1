namespace Task1.Core.Interfaces
{
    public interface IClientProductService
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<Client?> GetClientByCodeAsync(int code);
        Task<ClientProducts?> GetClientProductAsync(int productId, int clientId);
        Task<bool> ProductAlreadyAddedToClientAsync(int productId, int clientId);
        Task AddProductToClientAsync(Client client, Product product);
        Task UpdateClientProductAsync(ClientProducts clientProduct);
        Task DeleteClientProductAsync(ClientProducts clientProduct);
    }
}
