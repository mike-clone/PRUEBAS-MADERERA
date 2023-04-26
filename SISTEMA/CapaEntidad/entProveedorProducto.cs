namespace CapaEntidad
{
    public class entProveedorProducto
    {

        private entProveedor proveedor;
        private entProducto producto;
        private double precioCompra;

        public entProveedor Proveedor { get => proveedor; set => proveedor = value; }
        public entProducto Producto { get => producto; set => producto = value; }
        public double PrecioCompra { get => precioCompra; set => precioCompra = value; }
    }
}
