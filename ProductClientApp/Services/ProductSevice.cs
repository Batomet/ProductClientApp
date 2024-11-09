using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductClientApp.Model;

namespace ProductClientApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:44348/swagger/index.html";

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetStringAsync(BaseUrl);
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Product>(response);
        }

        public async Task AddProductAsync(Product product)
        {
            var jsonContent = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(BaseUrl, content);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var jsonContent = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{BaseUrl}/{product.Id}", content);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
        }
    }
}