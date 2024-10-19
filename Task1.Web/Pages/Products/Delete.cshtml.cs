

namespace Task1.Web.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DeleteModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductViewModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();

            ProductModel = _mapper.Map<ProductViewModel>(product);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound();

            if (await _productService.IsProductRelatedToClientAsync(product.Id))
            {
                ModelState.AddModelError(string.Empty,"");
                return Page();
            }

            await _productService.DeleteProductAsync(product);

            return RedirectToPage("./Index");
        }
    }
}
