using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;


namespace Task1.Core.Entities
{
    [Index(nameof(Code) ,IsUnique =true)]
    public class Client
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be 9 digits.")]
        public int Code { get; set; }

        public ClientClass Class { get; set; }

        public ClientState State { get; set; }

        public ICollection<ClientProducts>? Products { get; set; }
    }
}
