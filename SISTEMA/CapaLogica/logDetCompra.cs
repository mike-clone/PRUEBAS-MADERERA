using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logDetCompra
    {
        private static readonly logDetCompra _instancia = new logDetCompra();

        public static logDetCompra Instancia
        {
            get { return _instancia; }
        }
        public bool CrearDetCompra(entDetCompra comp)
        {
            return datDetCompra.Instancia.CrearDetCompra(comp);
        }
        public List<entDetCompra> MostrarDetalleCompraId(int id)
        {
            return datDetCompra.Instancia.MostrarDetalleCompraId(id);
        }


    }
}
