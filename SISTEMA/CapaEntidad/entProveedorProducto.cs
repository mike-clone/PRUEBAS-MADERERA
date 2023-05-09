namespace CapaEntidad
{
    public class EntProveedorProducto
    {

        private EntProveedor proveedor;
        private EntProducto producto;
        private double precioCompra;

        public EntProveedor Proveedor { get => proveedor; set => proveedor = value; }
        public EntProducto Producto { get => producto; set => producto = value; }
        public double PrecioCompra { get => precioCompra; set => precioCompra = value; }
    }
}
