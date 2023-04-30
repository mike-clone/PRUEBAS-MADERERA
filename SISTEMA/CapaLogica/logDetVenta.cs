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
        public List<entReporteVenta> MostrarReporteVenta(int idVenta)
        {
            return datDetVenta.Instancia.MostrarReporteVenta(idVenta);
        }
        //Carrito compras
        public bool LlenarDetventa(entDetVenta det)
        {
            return datDetVenta.Instancia.Llenardetventa(det);
        }
        public List<entDetVenta> Mostrardetventa(int idVenta)
        {
            return datDetVenta.Instancia.Mostrardetventa(idVenta);
        }
        public bool EliminarDetalle(int id)
        {
            return datDetVenta.Instancia.Eliminardetalle(id);
        }

        //public List<EntTemporaryProducts> MostrarCarrito(int idUsuario)
        //{
        //    return datDetVenta.Instancia.MostrarCarrito(idUsuario);
        //}
    }
}
