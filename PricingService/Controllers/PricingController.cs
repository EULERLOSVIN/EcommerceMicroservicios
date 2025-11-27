using Microsoft.AspNetCore.Mvc;

namespace PricingService.Controllers
{
    [Route("api/[controller]")] // Esto define la URL: api/pricing
    [ApiController]
    public class PricingController : ControllerBase
    {

        [HttpGet("calcular")]
        public IActionResult CalcularPrecio(int cantidad, decimal precio)
        {
            var calculadora = new CalculadoraPrecios();
            decimal total = calculadora.Calcular(cantidad, precio);
            return Ok(total);
        }
    }
}