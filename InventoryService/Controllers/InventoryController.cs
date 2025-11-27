using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet("verificar")]
        public bool VerificarStock(int idProducto, int cantidad)
        {
            string jsonTexto = System.IO.File.ReadAllText("data.json");
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var misProductos = JsonSerializer.Deserialize<List<Producto>>(jsonTexto, opciones);
            var productoEncontrado = misProductos.FirstOrDefault(p => p.Id == idProducto);
            if (productoEncontrado != null && productoEncontrado.Stock >= cantidad)
            {
                return true;
            }

            return false;
        }
    }
}