using ProductClientApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductClientApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);  
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);  
    }
}