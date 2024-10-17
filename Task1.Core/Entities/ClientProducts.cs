using System.ComponentModel.DataAnnotations;

namespace Task1.Core.Entities
{
    public class ClientProducts
    {
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; }

        [MaxLength(255)]
        public string License { get; set; } = null!;
    }
}
