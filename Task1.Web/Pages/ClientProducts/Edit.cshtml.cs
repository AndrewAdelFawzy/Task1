using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Core.Entities;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.ClientProducts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditClientProductViewModel ClientProductModel { get; set; } 
        public async Task<IActionResult> OnGet(int ClientId, int ProductId)
        {
            var clientProduct = await _context.ClientProducts
                                  .Include(cp=>cp.Product)
                                  .FirstOrDefaultAsync(cp => cp.ProductId == ProductId &&
                                                             cp.ClientId == ClientId);

            if (clientProduct is null || clientProduct.Product is null)
                return NotFound();

            ClientProductModel = new EditClientProductViewModel
            {
                ClientId = clientProduct.ClientId,
                ProductId = clientProduct.ProductId,
                Name = clientProduct.Product!.Name,
                StartDate = clientProduct.StartDate,
                EndDate = clientProduct.EndDate,
                Lisence = clientProduct.License,
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
                return Page();

            var clientProduct = await _context.ClientProducts
                                  .FirstOrDefaultAsync(cp => cp.ProductId == ClientProductModel.ProductId &&
                                                             cp.ClientId == ClientProductModel.ClientId);
            if(clientProduct is null)
                return NotFound();

            clientProduct.StartDate = ClientProductModel.StartDate;
            clientProduct.EndDate = ClientProductModel.EndDate;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Clients/Details", new { id = ClientProductModel.ClientId });
        }
    }
}
