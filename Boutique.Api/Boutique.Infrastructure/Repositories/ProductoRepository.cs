using Boutique.Domain.Entities;
using Boutique.Domain.Interfaces;
using Boutique.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Boutique.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto> Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> Update(Producto producto)
        {
            _context.Productos.Update(producto);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await GetById(id);
            if (p == null) return false;

            _context.Productos.Remove(p);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
