using System.Net.Http.Json;
using Boutique.Web.Models;

namespace Boutique.Web.Services
{
    public class ProductosService
    {
        private readonly HttpClient _http;

        public ProductosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _http.GetFromJsonAsync<List<Producto>>("api/Productos");
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            var response = await _http.PostAsJsonAsync("api/Productos", producto);
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task ActualizarProducto(Producto producto)
        {
            await _http.PutAsJsonAsync($"api/Productos/{producto.Id}", producto);
        }

        public async Task EliminarProducto(int id)
        {
            await _http.DeleteAsync($"api/Productos/{id}");
        }

    }
}
