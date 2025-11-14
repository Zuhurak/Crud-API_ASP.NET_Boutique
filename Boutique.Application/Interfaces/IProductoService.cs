using Boutique.Application.DTOs;

namespace Boutique.Application.Interfaces;

public interface IProductoService
{
    Task<List<ProductoDto>> GetAll();
    Task<ProductoDto> GetById(int id);
    Task<ProductoDto> Create(ProductoDto dto);
    Task Update(ProductoDto dto);
    Task Delete(int id);
}
