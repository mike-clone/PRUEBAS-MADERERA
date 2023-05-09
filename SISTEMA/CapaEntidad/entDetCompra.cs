
namespace CapaEntidad
{
    public class EntDetCompra
    {
        private EntCompra compra;
        private EntProveedorProducto proveedorProducto;
        private int cantidad;
        private double subtotal;

        public EntCompra Compra { get => compra; set => compra = value; }
        public EntProveedorProducto ProveedorProducto { get => proveedorProducto; set => proveedorProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
