using Microsoft.Maui.Controls;
using ProductClientApp.Model;
using ProductClientApp.Services;
using System.Threading.Tasks;

namespace ProductClientApp.Views
{
    [QueryProperty(nameof(ProductId), "id")]
    public partial class ProductDetailsPage : ContentPage
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        private readonly IProductService _productService;

        public ProductDetailsPage() : this(App.ServiceProvider.GetService<IProductService>()) { }

        public ProductDetailsPage(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            await LoadProductDetails();
        }

        private async Task LoadProductDetails()
        {
            if (ProductId != 0)
            {
                Product = await _productService.GetProductByIdAsync(ProductId);
                
                BindingContext = Product;
            }
            else
            {
                await DisplayAlert("Błąd", "Nie znaleziono produktu o podanym ID.", "OK");
            }
        }
    }
}