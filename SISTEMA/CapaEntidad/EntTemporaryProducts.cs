namespace CapaEntidad
{
    public class EntTemporaryProducts
    {
        public int IdTemp { get; set;}
        public EntProveedorProducto ProveedorProducto { get; set ; }
        public EntUsuario Usuario { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set;}  
    }
}
