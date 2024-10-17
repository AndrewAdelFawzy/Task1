using System.ComponentModel.DataAnnotations;


namespace Task1.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(150)]
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }

        public ICollection<ClientProducts>? Clients { get; set; }
    }
}
