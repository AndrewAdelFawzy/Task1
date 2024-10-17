using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client is null)
                return NotFound();

            ClientModel = new()
            {
                Name = client.Name,
                Code = client.Code,
                ClientId = id
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client is null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
