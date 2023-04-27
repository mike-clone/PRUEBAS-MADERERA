using System;

namespace CapaEntidad
{
    public class entDetCompra
    {
        private entCompra compra;
        private entProveedorProducto proveedorProducto;
        private int cantidad;
        private double subtotal;

        public entCompra Compra { get => compra; set => compra = value; }
        public entProveedorProducto ProveedorProducto { get => proveedorProducto; set => proveedorProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
