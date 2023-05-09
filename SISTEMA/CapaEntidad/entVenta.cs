using System;

namespace CapaEntidad
{
    public class EntVenta
    {
        private int idVenta;
        private DateTime fecha;
        private double total;
        private string estado;
        private EntUsuario cliente;

        #region Get and Set
        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Double Total
        {
            get { return total; }
            set { total = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public EntUsuario Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        #endregion Get and Set

    }
}
