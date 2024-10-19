namespace Task1.Web.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public EditModel(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client is null)
                return NotFound();

            ClientModel = _mapper.Map<ClientViewModel>(client);

            ClientModel.ClientClasses = _clientService.GetClientClasses(client.Class);
            ClientModel.ClientStates = _clientService.GetClientStates(client.State);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = await _clientService.GetClientByIdAsync(ClientModel.ClientId);
            if (client is null)
                return NotFound();

            _mapper.Map(ClientModel, client);

            await _clientService.UpdateClientAsync(client);
            return RedirectToPage("./Details", new { id = ClientModel.ClientId });
        }

    }
}
