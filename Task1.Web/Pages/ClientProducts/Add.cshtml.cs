using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Core.Entities;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.ClientProducts
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientProductViewModel ClientProductModel { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound();

            ClientProductModel = new()
            {
                ProductId = product.Id,
                Code = ""
            };

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
                return Page();

            var product = await _context.Products.FindAsync(ClientProductModel.ProductId);

            if (product is null)
                return NotFound();

            var client = await _context.Clients.Include(c=>c.Products).SingleOrDefaultAsync(c=>c.Code == ClientProductModel.Code);

            if (client is null)
                return NotFound();

            client.Products.Add(new()
            {
                ClientId = client.Id,
                ProductId = product.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                License= Guid.NewGuid().ToString()
            });

            await _context.SaveChangesAsync();

            return RedirectToPage("/Products/Index");

        }

        


    }
}
