using ProductClientApp.Model;
using ProductClientApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProductClientApp.Model;
using ProductClientApp.Services;

namespace ProductClientApp.ViewModels
{
    public class ProductEditViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        public ProductEditViewModel(IProductService productService, int? productId = null)
        {
            _productService = productService;
            if (productId.HasValue)
            {
                LoadProduct(productId.Value);
            }
            else
            {
                Product = new Product();
            }
        }

        public async void LoadProduct(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            Product = product;
        }

        public async void SaveProduct()
        {
            if (Product.Id == 0)
            {
                await _productService.AddProductAsync(Product);
            }
            else
            {
                await _productService.UpdateProductAsync(Product);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}