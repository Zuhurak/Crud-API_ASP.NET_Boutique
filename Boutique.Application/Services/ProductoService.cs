using Boutique.Application.DTOs;
using Boutique.Application.Interfaces;
using Boutique.Domain.Entities;
using Boutique.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Boutique.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDto>> GetAll()
        {
            return await _context.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .ToListAsync();
        }

        public async Task<ProductoDto> GetById(int id)
        {
            var p = await _context.Productos.FindAsync(id);

            if (p == null)
                return null;

            return new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            };
        }

        public async Task<ProductoDto> Create(ProductoDto dto)
        {
            var entidad = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock
            };

            _context.Productos.Add(entidad);
            await _context.SaveChangesAsync();

            dto.Id = entidad.Id;
            return dto;
        }

        public async Task Update(ProductoDto dto)
        {
            var entidad = await _context.Productos.FindAsync(dto.Id);

            if (entidad == null)
                return;

            entidad.Nombre = dto.Nombre;
            entidad.Precio = dto.Precio;
            entidad.Stock = dto.Stock;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entidad = await _context.Productos.FindAsync(id);

            if (entidad == null)
                return;

            _context.Productos.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
