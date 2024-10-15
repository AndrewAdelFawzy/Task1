using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound();

            Product = new()
            {
                Name = product.Name,
                Id = id
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
