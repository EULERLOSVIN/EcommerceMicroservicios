using Xunit;
using PricingService; // Importamos tu proyecto principal

namespace PricingService.Tests
{
    public class CalculadoraTests
    {
        [Theory] // Theory indica que es una prueba con múltiples datos (Tabla)
        [InlineData(5, 100, 500)]  // Caso 1: Compro 5 (Sin descuento). 5 * 100 = 500
        [InlineData(10, 100, 1000)] // Caso 2: Compro 10 (Límite, sin descuento). 10 * 100 = 1000
        [InlineData(11, 100, 990)]  // Caso 3: Compro 11 (CON descuento). 11 * 100 = 1100 - 10% = 990
        public void Calcular_DebeRetornarPrecioCorrecto(int cantidad, decimal precio, decimal esperado)
        {
            // 1. Preparar (Arrange)
            var calculadora = new CalculadoraPrecios();

            // 2. Ejecutar (Act)
            var resultadoReal = calculadora.Calcular(cantidad, precio);

            // 3. Verificar (Assert)
            Assert.Equal(esperado, resultadoReal);
        }
    }
}