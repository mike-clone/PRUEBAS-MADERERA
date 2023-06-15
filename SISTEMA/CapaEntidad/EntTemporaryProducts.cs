namespace CapaEntidad
{
    public class EntTemporaryProducts
    {
        private int idTemp;
        private EntProveedorProducto proveedorProducto;
        private EntUsuario usuario;
        private int cantidad;
        private double subtotal;

        public int IdTemp { get; set;}
        public EntProveedorProducto ProveedorProducto { get; set ; }
        public EntUsuario Usuario { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set;}
       
    }
}
