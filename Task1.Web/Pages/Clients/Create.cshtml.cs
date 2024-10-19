namespace Task1.Web.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public CreateModel(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        [BindProperty]
        public ClientViewModel ClientModel { get; set; }
        public void OnGet()
        {
            InitializeClientModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                InitializeClientModel(); 
                return Page();
            }

            var client = _mapper.Map<Client>(ClientModel);

            await _clientService.AddClientAsync(client);

            return RedirectToPage("./Index");
        }

        // populate ViewModel properties
        private void InitializeClientModel()
        {
            ClientModel = new ClientViewModel
            {
                ClientStates = GetSelectListFromEnum<ClientState>(),
                ClientClasses = GetSelectListFromEnum<ClientClass>()
            };
        }

        //to map enums to SelectListItem
        private List<SelectListItem> GetSelectListFromEnum<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)(object)e).ToString(),
                    Text = e.ToString()
                }).ToList();
        }
    }
}

