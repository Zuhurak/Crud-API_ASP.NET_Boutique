using Microsoft.AspNetCore.Mvc;
using Boutique.Application.Interfaces;
using Boutique.Application.DTOs;

namespace Boutique.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _servicio;

        public ProductosController(IProductoService servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _servicio.GetAll();
            return Ok(lista);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _servicio.GetById(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<IActionResult> Post(ProductoDto dto)
        {
            var creado = await _servicio.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            await _servicio.Update(dto);
            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicio.Delete(id);
            return NoContent();
        }
    }
}
