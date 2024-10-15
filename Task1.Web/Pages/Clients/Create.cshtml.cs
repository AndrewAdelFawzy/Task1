using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task1.Core.Entities;
using Task1.Core.Enums;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; }

        public void OnGet()
        {
            ClientModel = new ClientViewModel
            {
                ClientStates = Enum.GetValues(typeof(ClientState))
                .Cast<ClientState>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }).ToList(),

                ClientClasses = Enum.GetValues(typeof(ClientClass))
                .Cast<ClientClass>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }).ToList()
            };
        }
        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }

            Client client = new()
            {
                Name = ClientModel.Name,
                Code = ClientModel.Code,
                State = ClientModel.State,
                Class = ClientModel.Class,
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
