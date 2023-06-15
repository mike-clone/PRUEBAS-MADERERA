namespace CapaEntidad
{
    public class EntProveedorProducto
    {

        public EntProveedor Proveedor {
            get;
            set;
        }
        public EntProducto Producto {
            get;
            set;
        }
        public double PrecioCompra { get; set; }
    }
}
