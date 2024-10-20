﻿namespace Task1.Web.ViewModels
{
    public class ClientProductsDetailsViewModel
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(150)]
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }

        [Display(Name= "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string Lisence { get; set; } = null!;
    }
}
