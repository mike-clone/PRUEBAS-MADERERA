namespace CapaEntidad
{
    public class EntProducto
    {
       
        private readonly string nombre;
        private readonly double longitud;
        private readonly double diametro;
        public string NombreCompleto
        {
            get { return nombre + " - " + longitud + "MT - " + diametro + "Ø"; }
        }

        #region Get and Set
        public int IdProducto
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public double Diametro
        {
            get;
            set;
        }
        public double Longitud
        {
            get;
            set;
        }

        public double PrecioVenta
        {
            get;
            set;
        }
        public EntTipoProducto Tipo
        {
            get;
            set;
        }
        public int Stock
        {
            get;
            set;
        }


        public bool Activo {
            get;
            set;
        }

        #endregion Get and Set
    }
}
