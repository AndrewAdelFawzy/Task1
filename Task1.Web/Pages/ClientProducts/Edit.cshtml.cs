namespace Task1.Web.Pages.ClientProducts
{
    public class EditModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        private readonly IMapper _mapper;

        public EditModel(IClientProductService clientProductService, IMapper mapper)
        {
            _clientProductService = clientProductService;
            _mapper = mapper;
        }

        [BindProperty]
        public EditClientProductViewModel ClientProductModel { get; set; }
        public async Task<IActionResult> OnGetAsync(int ClientId, int ProductId)
        {
            var clientProduct = await _clientProductService.GetClientProductAsync(ProductId, ClientId);

            if (clientProduct is null || clientProduct.Product is null )
                return NotFound();

            ClientProductModel = _mapper.Map<EditClientProductViewModel>(clientProduct);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var clientProduct = await _clientProductService
                                .GetClientProductAsync(ClientProductModel.ProductId, ClientProductModel.ClientId);
            if (clientProduct is null)
                return NotFound();

            _mapper.Map(ClientProductModel, clientProduct);

            await _clientProductService.UpdateClientProductAsync(clientProduct);

            return RedirectToPage("/Clients/Details", new { id = ClientProductModel.ClientId });
        }
    }
}
