using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;
namespace CapaLogica
{
    public class logDetVenta
    {
        private static readonly logDetVenta _instancia = new logDetVenta();

        public static logDetVenta Instancia
        {
            get { return _instancia; }
        }

        public bool CrearDetVenta(entDetVenta det)
        {
            return datDetVenta.Instancia.CrearDetVenta(det);
        }
       
        //Carrito compras
      
        public List<entDetVenta> Mostrardetventa(int idVenta)
        {
            return datDetVenta.Instancia.Mostrardetventa(idVenta);
        }
       
    }
}
