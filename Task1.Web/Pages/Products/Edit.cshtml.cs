namespace Task1.Web.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public EditModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductViewModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            ProductModel = _mapper.Map<ProductViewModel>(product);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = await _productService.GetProductByIdAsync(ProductModel.Id);

            if (product is null)
                return NotFound();

            _mapper.Map(ProductModel, product);

            await _productService.UpdateProductAsync(product);

            return RedirectToPage("./Index");
        }
    }
}
