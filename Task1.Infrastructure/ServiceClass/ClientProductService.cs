namespace Task1.Infrastructure.ServiceClass
{
    public class ClientProductService :IClientProductService
    {
        private readonly ApplicationDbContext _context;

        public ClientProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Client?> GetClientByCodeAsync(int code)
        {
            return await _context.Clients
                .Include(c => c.Products)
                .SingleOrDefaultAsync(c => c.Code == code);
        }

        public async Task<bool> ProductAlreadyAddedToClientAsync(int productId, int clientId)
        {
            return await _context.ClientProducts
                .AnyAsync(cp => cp.ProductId == productId && cp.ClientId == clientId);
        }

        public async Task AddProductToClientAsync(Client client, Product product)
        {
            client.Products?.Add(new ()
            {
                ClientId = client.Id,
                ProductId = product.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                License = Guid.NewGuid().ToString()
            });

            await _context.SaveChangesAsync();
        }

        public async Task<ClientProducts?> GetClientProductAsync(int productId, int clientId)
        {
            return await _context.ClientProducts
                 .Include(cp => cp.Product)
                .SingleOrDefaultAsync(cp => cp.ProductId == productId && cp.ClientId == clientId);
        }

        public async Task UpdateClientProductAsync(ClientProducts clientProduct)
        {
            _context.ClientProducts.Update(clientProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientProductAsync(ClientProducts clientProduct)
        {
            _context.ClientProducts.Remove(clientProduct);
            await _context.SaveChangesAsync();
        }
    }
}
