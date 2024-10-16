using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Task1.Core.Entities;
using Task1.Core.Enums;

namespace Task1.Web.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(9)]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be 9 digits.")]
        public string Code { get; set; } = null!;

        public ClientClass Class { get; set; }

        public ClientState State { get; set; }

        public List<SelectListItem>? ClientStates { get; set; } = null!;

        public List<SelectListItem>? ClientClasses { get; set; } = null!;

        public List<ClientProductsDetailsViewModel>? Products { get; set; }
    }
}
