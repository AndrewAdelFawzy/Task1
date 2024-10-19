namespace Task1.Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DetailsModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductViewModel ProductModel { get; set; } = new ProductViewModel();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();

            ProductModel = _mapper.Map<ProductViewModel>(product);

            return Page();
        }
    }
}
