namespace Task1.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductViewModel ProductModel { get; set; }

        public void OnGet()
        {
        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            
            var product = _mapper.Map<Product>(ProductModel);

            await _productService.AddProductAsync(product);

            return RedirectToPage("./Index");
        }
    }
}
