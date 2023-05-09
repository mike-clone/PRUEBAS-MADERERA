namespace CapaEntidad
{
    public class entProveedorProducto
    {

        private entProveedor proveedor;
        private EntProducto producto;
        private double precioCompra;

        public entProveedor Proveedor { get => proveedor; set => proveedor = value; }
        public EntProducto Producto { get => producto; set => producto = value; }
        public double PrecioCompra { get => precioCompra; set => precioCompra = value; }
    }
}
