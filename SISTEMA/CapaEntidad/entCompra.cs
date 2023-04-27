using System;

namespace CapaEntidad
{
    public class entCompra
    {
        private int idCompra;
        private DateTime fecha;
        private double total;
        private entUsuario usuario;
        private string estado;


     


        #region Get and Set
        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

      
        public string Estado { get => estado; set => estado = value; }
        public entUsuario Usuario { get => usuario; set => usuario = value; }
        #endregion Get and Set
    }
}
