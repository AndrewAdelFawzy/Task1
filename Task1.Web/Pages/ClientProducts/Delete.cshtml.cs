using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Core.Entities;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.ClientProducts
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeleteClientProductViewModel deleteClientProduct { get; set; }

        public async Task<IActionResult> OnGet(int ProductId, int ClientId)
        {
            var clientProduct = await _context.ClientProducts
                .SingleOrDefaultAsync(cp => cp.ProductId == ProductId && cp.ClientId == ClientId);

            if (clientProduct is null)
                return NotFound();

            deleteClientProduct = new()
            {
                ClientId = ClientId,
                ProductId = ProductId
            };

            return Page();

        }

        public IActionResult OnPost()
        {
            var clientProduct =  _context.ClientProducts
            .SingleOrDefault(cp => cp.ProductId == deleteClientProduct.ProductId &&
                                        cp.ClientId == deleteClientProduct.ClientId);

            if (clientProduct is null)
                return NotFound();

            _context.Remove(clientProduct);
            _context.SaveChanges();

            return RedirectToPage("/Clients/Details", new { id = deleteClientProduct.ClientId });
        }


    }
}
