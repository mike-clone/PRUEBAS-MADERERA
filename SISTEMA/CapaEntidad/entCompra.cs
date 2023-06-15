using System;

namespace CapaEntidad
{
    public class EntCompra
    {
  
        public string Estado { get; set; }
        public EntUsuario Usuario { get; set; }


        #region Get and Set
        public int IdCompra
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }
        public double Total
        {
            get;
            set;
        }

      
       
        #endregion Get and Set
    }
}
