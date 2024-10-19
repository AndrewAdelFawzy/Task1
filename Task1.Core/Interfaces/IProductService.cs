namespace Task1.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task<bool> IsProductRelatedToClientAsync(int productId);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
