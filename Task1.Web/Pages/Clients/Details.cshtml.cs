using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; } = new ClientViewModel();

        public async Task<IActionResult> OnGet(int id)
        {
            var client = await _context.Clients
                                        .Include(c => c.Products!)
                                        .ThenInclude(cp=>cp.Product)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (client is null)
                return NotFound();

            ClientModel = new ClientViewModel
            {
                Id= id,
                Name = client.Name,
                Code = client.Code,
                State = client.State,
                Class = client.Class,
                Products = client.Products!
                .Select(cp => new ClientProductsDetailsViewModel
                {
                    Name = cp.Product!.Name,
                    Description = cp.Product.Description,
                    IsActive = cp.Product.IsActive,
                    StartDate = cp.StartDate,
                    EndDate = cp.EndDate,
                    Lisence = cp.License
                    
                }).OrderBy(cp=>cp.Name)
                .ToList(),
                
            };

            return Page();
        }
    }
}
