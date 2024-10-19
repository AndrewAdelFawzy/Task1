namespace Task1.Web.Pages.ClientProducts
{
    public class DeleteModel : PageModel
    {
        private readonly IClientProductService _clientProductService;

        public DeleteModel(IClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        [BindProperty]
        public DeleteClientProductViewModel DeleteClientProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int productId, int clientId)
        {
            var clientProduct = await _clientProductService.GetClientProductAsync(productId, clientId);

            if (clientProduct is null)
                return NotFound();

            DeleteClientProduct = new ()
            {
                ClientId = clientId,
                ProductId = productId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var clientProduct = await _clientProductService.GetClientProductAsync(DeleteClientProduct.ProductId, DeleteClientProduct.ClientId);

            if (clientProduct is null)
                return NotFound();

            await _clientProductService.DeleteClientProductAsync(clientProduct);

            return RedirectToPage("/Clients/Details", new { id = DeleteClientProduct.ClientId });
        }


    }
}
