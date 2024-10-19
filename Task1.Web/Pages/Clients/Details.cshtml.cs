namespace Task1.Web.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly IClientService _clientService;
        public DetailsModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; } = new ClientViewModel();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = await _clientService.GetClientWithProductsByIdAsync(id);

            if (client is null)
                return NotFound();

            ClientModel = new ClientViewModel
            {
                ClientId= id,
                Name = client.Name,
                Code = client.Code,
                State = client.State,
                Class = client.Class,
                Products = client.Products!
                .Select(cp => new ClientProductsDetailsViewModel
                {
                    ProductId = cp.Product!.Id,
                    Name = cp.Product!.Name,
                    Description = cp.Product.Description,
                    IsActive = cp.Product.IsActive,
                    StartDate = cp.StartDate,
                    EndDate = cp.EndDate,
                    Lisence = cp.License
                    
                }).OrderBy(cp=>cp.Name)
                .ToList(),
                
            };

            return Page();
        }
    }
}
