namespace PricingService
{
    public class CalculadoraPrecios
    {
        public decimal Calcular(int cantidad, decimal precioUnitario)
        {
            decimal total = cantidad * precioUnitario;
            if (cantidad > 10)
            {
                return total * 0.90m;
            }
            return total;
        }
    }
}