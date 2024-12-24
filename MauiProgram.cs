using CommunityToolkit.Maui;
using MeijerProject.Services;
using MeijerProject.Services.Interfaces;
using MeijerProject.ViewModels;
using MeijerProject.Views;
using Microsoft.Extensions.Logging;

namespace MeijerProject
{
    public static class MauiProgram
    {
        public static IServiceProvider? Provider;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            RegisterServices(builder.Services);
            RegisterViews(builder.Services);
            RegisterViewModels(builder.Services);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            Provider = app.Services;
            return app;
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<HttpClient>(new HttpClient { BaseAddress = new Uri("https://meijer-maui-test-default-rtdb.firebaseio.com") });
        }
        
        public static void RegisterViews(IServiceCollection services)
        {
            services.AddTransient<ProductListView>();
            services.AddTransient<ProductDetailView>();
        }

        public static void RegisterViewModels(IServiceCollection services)
        {
            services.AddTransient<ProductListViewModel>();
            services.AddTransient<ProductDetailViewModel>();
        }
    }
}
