using AnishSqlWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var azureAppConfigConnectionString = "Endpoint=https://anishappconfig.azconfig.io;Id=MMoC-l8-s0:Vwp9oFpl9fWJDCN2eX/v;Secret=/veqyiT9UNnz9PnGSQ6It0M6MZeOcG01YVVttx0RLEo=";

builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(azureAppConfigConnectionString);
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
