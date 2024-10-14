using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Core.Entities;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public async Task<IActionResult> OnGet()
        {
            Products = await _context.Products
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Description = p.Description,
                    IsActive = p.IsActive,
                })
                .OrderBy(p => p.Name)
                .ToListAsync();

            return Page();
        }
    }
}
