using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Core.Entities;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductFormViewModel Product { get; set; }
        
        public void OnGet()
        {

        }

        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
           
            Product product = new()
            {
                Name = Product.Name,
                Description = Product.Description,
                IsActive = Product.IsActive,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
