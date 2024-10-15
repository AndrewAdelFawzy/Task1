using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Task1.Core.Enums;
using Microsoft.EntityFrameworkCore;


namespace Task1.Core.Entities
{
    [Index(nameof(Code) ,IsUnique =true)]
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(9)]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be 9 digits.")]
        public string Code { get; set; } =null!;

        public ClientClass Class { get; set; }

        public ClientState State { get; set; }
    }
}
