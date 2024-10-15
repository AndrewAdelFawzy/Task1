using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var client = await _context.Clients.FindAsync(id);

            if (client is null)
                return NotFound();

            ClientModel.Name = client.Name;
            ClientModel.Code = client.Code;
            ClientModel.State = client.State;
            ClientModel.Class = client.Class;


            return Page();
        }
    }
}
