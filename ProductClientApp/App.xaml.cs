using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ProductClientApp.Services;
using ProductClientApp.ViewModels;
using ProductClientApp.Views;

namespace ProductClientApp
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            MainPage = new AppShell();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<ProductDetailsPage>();
        }
    }

}