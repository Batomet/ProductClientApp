using Microsoft.Maui.Controls;
using ProductClientApp.Model;
using ProductClientApp.ViewModels;
using ProductClientApp.Services;

namespace ProductClientApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage() : this(App.ServiceProvider.GetService<IProductService>()) { }

        public MainPage(IProductService productService)
        {
            InitializeComponent();
            BindingContext = new ProductViewModel(productService);
        }
    }

}