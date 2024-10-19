namespace Task1.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public IndexModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IList<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var products = await _productService.GetAllProductsAsync();

            Products = _mapper.Map<List<ProductViewModel>>(products);

            return Page();
        }
    }
}
