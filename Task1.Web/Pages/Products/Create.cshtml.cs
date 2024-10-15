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
        public ProductViewModel ProductModel { get; set; }
        
        public void OnGet()
        {

        }

        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
           
            Product product = new()
            {
                Name = ProductModel.Name,
                Description = ProductModel.Description,
                IsActive = ProductModel.IsActive,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
