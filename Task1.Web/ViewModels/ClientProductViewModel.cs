﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Task1.Core.Entities;

namespace Task1.Web.ViewModels
{
    public class ClientProductViewModel
    {
        [MaxLength(9)]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be 9 digits.")]
        public string Code { get; set; } =null!;

        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
