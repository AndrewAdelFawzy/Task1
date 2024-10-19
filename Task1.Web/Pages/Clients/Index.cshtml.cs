namespace Task1.Web.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public IndexModel(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        public IList<ClientViewModel> Clients { get; set; } = new List<ClientViewModel>();
        public async Task<IActionResult> OnGet()
        {
            var clients = await _clientService.GetAllClientsAsync();

            Clients = _mapper.Map<IList<ClientViewModel>>(clients);

            return Page();
        }
    }
}
