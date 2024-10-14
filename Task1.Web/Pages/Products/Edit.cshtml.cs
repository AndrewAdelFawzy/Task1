using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

             Product = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = await _context.Products.FindAsync(Product.Id);

            if (product is null)
                return NotFound();

            product.Name = Product.Name;
            product.Description = Product.Description;
            product.IsActive = Product.IsActive;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
