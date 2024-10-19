using Microsoft.AspNetCore.Mvc.Rendering;
using Task1.Core.Enums;


namespace Task1.Infrastructure.ServiceClass
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<IList<Client>> GetAllClientsAsync()
        {
            return await _context.Clients
                .OrderBy(p => p.Code)
                .ToListAsync();
        }


        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
             _context.Update(client);
            await _context.SaveChangesAsync();
        }

        public List<SelectListItem> GetClientClasses(ClientClass selectedClass)
        {
            return Enum.GetValues(typeof(ClientClass))
                       .Cast<ClientClass>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = e.ToString(),
                           Selected = e.Equals(selectedClass)
                       }).ToList();
        }

        public List<SelectListItem> GetClientStates(ClientState selectedState)
        {
            return Enum.GetValues(typeof(ClientState))
                       .Cast<ClientState>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = e.ToString(),
                           Selected = e.Equals(selectedState)
                       }).ToList();
        }

        public async Task<Client> GetClientWithProductsByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.Products)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteClientAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
