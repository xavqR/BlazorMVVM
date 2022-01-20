using BlazorMVVM.Data;
using BlazorMVVM.Pages.Counter;
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
            serviceCollection.AddSingleton<WeatherForecastService>();
            ConfigureCounterServices(serviceCollection);
        }

        private static void ConfigureCounterServices(IServiceCollection serviceCollection)
        {
            CounterVM counterVM = new();
            CounterModel counterModel = new();
            serviceCollection.AddTransient<IVMInitializer>(x => new CounterVMInitializer(counterVM));
            serviceCollection.AddTransient<ICounterVMCommandManager>(x => new CounterVMCommandManager(counterModel));
            serviceCollection.AddTransient<IVMDataSource>(x => new CounterVMDataSource(counterVM, counterModel));
            serviceCollection.AddTransient<ICounterFactory>(x => new CounterFactory(counterVM, x.GetRequiredService<IVMDataSource>(), x.GetRequiredService<IVMInitializer>(), x.GetRequiredService<ICounterVMCommandManager>()));
        }
    }
}