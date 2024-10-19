namespace Task1.Web.Pages.ClientProducts
{
    public class AddModel : PageModel
    {
        private readonly IClientProductService _clientProductService;

        public AddModel(IClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        [BindProperty]
        public ClientProductViewModel ClientProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _clientProductService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();

            ClientProductModel = new ClientProductViewModel
            {
                ProductId = product.Id
            };

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = await _clientProductService.GetProductByIdAsync(ClientProductModel.ProductId);
            if (product is null)
                return NotFound();

            var client = await _clientProductService.GetClientByCodeAsync(ClientProductModel.Code);
            if (client is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid client code");
                return Page();
            }

            var productExist = await _clientProductService.ProductAlreadyAddedToClientAsync(product.Id, client.Id);
            if (productExist)
            {
                ModelState.AddModelError(string.Empty, "Product already added to this client before");
                return Page();
            }

            await _clientProductService.AddProductToClientAsync(client, product);

            return RedirectToPage("/Products/Index");

        }

        


    }
}
