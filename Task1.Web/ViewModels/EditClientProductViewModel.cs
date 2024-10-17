using System.ComponentModel.DataAnnotations;
using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace Task1.Web.ViewModels
{
    public class EditClientProductViewModel
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Display(Name = "Start Date")]
        [AssertThat("StartDate >= Today()")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [AssertThat("EndDate >= Today()")]
        public DateTime? EndDate { get; set; }
        public string Lisence { get; set; } = null!;
    }
}
