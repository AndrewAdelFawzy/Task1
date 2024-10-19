namespace Task1.Web.ViewModels
{
    public class ClientProductViewModel
    {
        
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Code must be 9 digits.")]
        public int Code { get; set; } 

        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
