using BlazorMVVM.Data;
using BlazorMVVM.Pages.Counter;
using Infrastructure.MVVM;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<CounterVM>();
builder.Services.AddScoped<CounterModel>();
builder.Services.AddScoped<IFactory, CounterFactory>();
builder.Services.AddScoped<IVMInitializer, CounterVMInitializer>();
builder.Services.AddScoped<ICounterVMCommandManager, CounterVMCommandManager>();
builder.Services.AddScoped<IVMDataSource, CounterVMDataSource>();

var app = builder.Build();

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
