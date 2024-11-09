using ProductClientApp.Model;
using ProductClientApp.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ProductClientApp.ViewModels
{
    public class ProductDetailsViewModel : BindableObject
    {
        private readonly IProductService _productService;
        public Product Product { get; set; }

        public ProductDetailsViewModel() : this(App.ServiceProvider?.GetService<IProductService>()) { }

        public ProductDetailsViewModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task LoadProductDetails(int productId)
        {
            Product = await _productService.GetProductByIdAsync(productId);
            OnPropertyChanged(nameof(Product));
        }
    }
}