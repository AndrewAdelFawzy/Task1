namespace Task1.Web.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public DeleteModel(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
                return NotFound();

            ClientModel = _mapper.Map<ClientViewModel>(client);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
                return NotFound();

            await _clientService.DeleteClientAsync(client);

            return RedirectToPage("./Index");
        }
    }
}
