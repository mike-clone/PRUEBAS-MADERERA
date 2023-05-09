namespace CapaEntidad
{
    public class EntTemporaryProducts
    {
        private int idTemp;
        private EntProveedorProducto proveedorProducto;
        private EntUsuario usuario;
        private int cantidad;
        private double subtotal;

        public int IdTemp { get => idTemp; set => idTemp = value; }
        public EntProveedorProducto ProveedorProducto { get => proveedorProducto; set => proveedorProducto = value; }
        public EntUsuario Usuario { get => usuario; set => usuario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
       
    }
}
