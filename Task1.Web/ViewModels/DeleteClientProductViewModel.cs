using Task1.Core.Entities;

namespace Task1.Web.ViewModels
{
    public class DeleteClientProductViewModel
    {
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
