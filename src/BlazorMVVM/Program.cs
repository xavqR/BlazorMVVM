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
            serviceCollection.AddScoped<CounterVM>();
            serviceCollection.AddScoped<CounterModel>();
            serviceCollection.AddTransient<IVMInitializer, CounterVMInitializer>(x => new CounterVMInitializer(x.GetRequiredService<CounterVM>()));
            serviceCollection.AddTransient<CounterVMDataSource>(x => new CounterVMDataSource(x.GetRequiredService<CounterVM>(), x.GetRequiredService<CounterModel>()));
            serviceCollection.AddTransient<ICounterVMCommandManager>(x => new CounterVMCommandManager(x.GetRequiredService<CounterModel>()));
            serviceCollection.AddTransient<ICounterFactory>(x => new CounterFactory(x.GetRequiredService<CounterVM>(), x.GetRequiredService<IResolver<IVMDataSource>>(), x.GetRequiredService<IVMInitializer>(), x.GetRequiredService<ICounterVMCommandManager>()));
        }

        private static void ConfigureFetchDataServices(IServiceCollection serviceCollection)
        {          
            serviceCollection.AddScoped<FetchDataVM>();
            serviceCollection.AddScoped<FetchDataModel>();
            serviceCollection.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            serviceCollection.AddTransient<IVMInitializerAsync, FetchDataVMInitializer>(x => new FetchDataVMInitializer(x.GetRequiredService<FetchDataModel>(), x.GetRequiredService<IWeatherForecastService>()));
            serviceCollection.AddTransient<FetchDataVMDataSource>(x => new FetchDataVMDataSource(x.GetRequiredService<FetchDataVM>(), x.GetRequiredService<FetchDataModel>()));
            serviceCollection.AddTransient<IFetchDataFactory>(x => new FetchDataFactory(x.GetRequiredService<FetchDataVM>(), x.GetRequiredService<IResolver<IVMDataSource>>(), x.GetRequiredService<IVMInitializerAsync>()));
        }

        private static void ConfigureResolvers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IResolver<IVMDataSource>, VMDataSourceResolver>();
        }
    }
}