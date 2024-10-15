using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ClientViewModel> Clients { get; set; } = new List<ClientViewModel>();
        public async Task<IActionResult> OnGet()
        {
           Clients = await _context.Clients
                .Select(p => new ClientViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Class = p.Class,
                    State = p.State,
                })
                .OrderBy(p => p.Code)
                .ToListAsync();

            return Page();
        }
    }
}
