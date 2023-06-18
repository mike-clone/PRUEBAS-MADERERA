namespace CapaEntidad
{
    public class EntProducto
    {
       
       
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
        public string NombreCompleto
        {
            get { return Nombre + " - " + Longitud + "MT - " + Diametro + "Ø"; }
        }

        #endregion Get and Set
    }
}
