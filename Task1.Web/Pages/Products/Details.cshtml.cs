using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = new ProductViewModel();

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound();

            Product.Id = id;
            Product.Name = product.Name;
            Product.Description = product.Description;
            Product.IsActive = product.IsActive;

            return Page();
        }
    }
}
