using System;

namespace CapaEntidad
{
    public class EntVenta
    {

        #region Get and Set
        public int IdVenta
        {
            get; set;
        }
        public DateTime Fecha
        {
            get; set;
        }
        public Double Total
        {
            get; set;
        }
        public string Estado
        {
            get; set;
        }
        public EntUsuario Cliente
        {
            get; set;
        }
        #endregion Get and Set

    }
}
