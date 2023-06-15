
namespace CapaEntidad
{
    public class EntDetCompra
    {

        public EntCompra Compra { get; set; }
        public EntProveedorProducto ProveedorProducto { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}
