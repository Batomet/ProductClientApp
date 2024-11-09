using ProductClientApp.Model;
using ProductClientApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ProductClientApp.ViewModels
{
    public class ProductViewModel : BindableObject
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; set; }
        public ICommand LoadProductsCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand ViewProductCommand { get; }

        // Default parameterless constructor for XAML instantiation
        public ProductViewModel() : this(App.ServiceProvider?.GetService<IProductService>()) { }

        // Constructor that receives IProductService via dependency injection
        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await LoadProducts());
            DeleteProductCommand = new Command<int>(async (id) => await DeleteProduct(id));
            AddProductCommand = new Command(async () => await AddProduct());
            ViewProductCommand = new Command<int>(async (id) => await ViewProductDetails(id));
        }

        private async Task LoadProducts()
        {
            var products = await _productService.GetProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        private async Task DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            await LoadProducts(); // Refresh the list after deletion
        }

        private async Task AddProduct()
        {
            var newProduct = new Product
            {
                Name = "New Product",
                Price = 0.0m,
                Stock = 0
            };

            await _productService.AddProductAsync(newProduct);
            await LoadProducts(); // Refresh the list after adding
        }

        private async Task ViewProductDetails(int id)
        {
            await Shell.Current.GoToAsync($"productdetails?id={id}");
        }
    }
}
