namespace CapaEntidad
{
    public class EntProducto
    {
       
        private int idProducto;
        private string nombre;
        private double longitud;
        private double diametro;
        private double precioVenta;
        private EntTipoProducto tipo;
        private int stock;
        private bool activo;
        public string NombreCompleto
        {
            get { return nombre + " - " + longitud + "MT - " + diametro + "Ø"; }
        }

        #region Get and Set
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public double Diametro
        {
            get { return diametro; }
            set { diametro = value; }
        }
        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public EntTipoProducto Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }


        public bool Activo { get => activo; set => activo = value; }

        #endregion Get and Set
    }
}
