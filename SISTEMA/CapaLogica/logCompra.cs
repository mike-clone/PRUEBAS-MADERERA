using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Data;

namespace CapaLogica
{
    public class logCompra
    {
        private static readonly logCompra _instancia = new logCompra();

        public static logCompra Instancia
        {
            get { return _instancia; }
        }

        public int CrearCompra(entCompra comp)
        {
            return datCompra.Instancia.CrearCompra(comp);
        }
        public List<entCompra> ListarCompra(int id)
        {
            return datCompra.Instancia.ListarCompra(id);
        }
        public List<entCompra> ListartodasLasCompras()
        {
            return datCompra.Instancia.ListarTodasLasCompras();
        }
        public bool EliminarCompra(int comp)
        {
            return datCompra.Instancia.EliminarCompra(comp);
        }
        //public int DevolverID(string tipo)
        //{
        //    return datCompra.Instancia.GenerarID(tipo);
        //}
        public List<entCompra> BuscarCompra(string busqueda)
        {
            return datCompra.Instancia.BuscarCompra(busqueda);
        }
    }
}
