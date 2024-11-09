using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProductClientApp.Model;
using ProductClientApp.Services;

namespace ProductClientApp.ViewModel

{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(IProductService productService)
        {
            _productService = productService;
            LoadProducts();
        }

        public async void LoadProducts()
        {
            var products = await _productService.GetProductsAsync();
            Products = new ObservableCollection<Product>(products);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}