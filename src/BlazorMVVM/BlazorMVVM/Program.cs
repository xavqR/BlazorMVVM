using BlazorMVVM.Data;
using BlazorMVVM.Pages.Counter;
using BlazorMVVM.Pages.FetchData;
using BlazorMVVM.Resolvers;
using Infrastructure.MVVM;

namespace BlazorMVVM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            ConfigureServices(builder.Services);
            ConfigureResolvers(builder.Services);

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigureCounterServices(serviceCollection);
            ConfigureFetchDataServices(serviceCollection);
        }

        private static void ConfigureCounterServices(IServiceCollection serviceCollection)
        {
            CounterVM counterVM = new();
            CounterModel counterModel = new();
            serviceCollection.AddTransient<CounterVMInitializer>(x => new CounterVMInitializer(counterVM));
            serviceCollection.AddTransient<CounterVMDataSource>(x => new CounterVMDataSource(counterVM, counterModel));
            serviceCollection.AddTransient<ICounterVMCommandManager>(x => new CounterVMCommandManager(counterModel));          
            serviceCollection.AddTransient<ICounterFactory>(x => new CounterFactory(counterVM, x.GetRequiredService<IResolver<IVMDataSource>>(), x.GetRequiredService<IResolver<IVMInitializer>>(), x.GetRequiredService<ICounterVMCommandManager>()));
        }

        private static void ConfigureFetchDataServices(IServiceCollection serviceCollection)
        {
            FetchDataVM fetchDataVM = new();
            FetchDataModel fetchDataModel = new();
            serviceCollection.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            serviceCollection.AddTransient<FetchDataVMInitializer>(x => new FetchDataVMInitializer(fetchDataModel, x.GetRequiredService<IWeatherForecastService>()));
            serviceCollection.AddTransient<FetchDataVMDataSource>(x => new FetchDataVMDataSource(fetchDataVM, fetchDataModel));
            serviceCollection.AddTransient<IFetchDataFactory>(x => new FetchDataFactory(fetchDataVM, x.GetRequiredService<IResolver<IVMDataSource>>(), x.GetRequiredService<IResolver<IVMInitializer>>()));
        }

        private static void ConfigureResolvers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IResolver<IVMInitializer>, VMInitializerResolver>();
            serviceCollection.AddTransient<IResolver<IVMDataSource>, VMDataSourceResolver>();
        }
    }
}