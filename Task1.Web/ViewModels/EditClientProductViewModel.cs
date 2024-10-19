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
        [AssertThat("StartDate >= Today()" , ErrorMessage = "The start date must be today or later")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [AssertThat("EndDate >= Today()", ErrorMessage = "The End date must be today or later")]
        public DateTime? EndDate { get; set; }

        public string License { get; set; } = null!;
    }
}
