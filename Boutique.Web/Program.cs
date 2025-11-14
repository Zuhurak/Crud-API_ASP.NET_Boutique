using Boutique.Web;
using Boutique.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar HttpClient apuntando a la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7223/")
});

// Registrar servicio de productos
builder.Services.AddScoped<ProductosService>();

await builder.Build().RunAsync();
