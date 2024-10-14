using System.ComponentModel.DataAnnotations;

namespace Task1.Web.ViewModels
{
    public class ProductFormViewModel
    {
        
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(150)]
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
