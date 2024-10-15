using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task1.Core.Entities;
using Task1.Core.Enums;
using Task1.Infrastructure;
using Task1.Web.ViewModels;

namespace Task1.Web.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
                Id = client.Id,
                Name = client.Name,
                Code = client.Code,
                Class = client.Class,
                State = client.State,
            };

            ClientModel.ClientClasses = Enum.GetValues(typeof(ClientClass))
                                  .Cast<ClientClass>()
                                  .Select(e => new SelectListItem
                                  {
                                      Value = e.ToString(),
                                      Text = e.ToString(),
                                      Selected = (e == client.Class)  // Preselect the current value
                                  }).ToList();

            ClientModel.ClientStates = Enum.GetValues(typeof(ClientState))
                                      .Cast<ClientState>()
                                      .Select(e => new SelectListItem
                                      {
                                          Value = e.ToString(),
                                          Text = e.ToString(),
                                          Selected = (e == client.State)  // Preselect the current value
                                      }).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
                
            var client = await _context.Clients.FindAsync(ClientModel.Id);

            if (client is null)
                return NotFound();

            client.Name = ClientModel.Name;
            client.Code = ClientModel.Code;
            client.State = ClientModel.State;
            client.Class = ClientModel.Class;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
