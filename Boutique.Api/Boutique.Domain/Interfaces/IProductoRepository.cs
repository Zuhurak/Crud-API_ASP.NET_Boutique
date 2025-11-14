using Boutique.Domain.Entities;

namespace Boutique.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> GetById(int id);
        Task<Producto> Add(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> Delete(int id);
    }
}
