using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{

    public class logProveedorProducto
    {
        private static readonly logProveedorProducto _instancia = new logProveedorProducto();
        public static logProveedorProducto Instancia
        {
            get { return _instancia; }
        }

        public bool CrearProveedorProducto(EntProveedorProducto prod)
        {
            return datProveedorProducto.Instancia.CrearProveedorProducto(prod);

        }
        public List<EntProveedorProducto> ListarProductoParaComprar()
        {
            return datProveedorProducto.Instancia.ListarProductoParaComprar();
        }

        public List<EntProveedorProducto> MostrarDetalleProvedorId(int idProveedor)
        {
            return datProveedorProducto.Instancia.MostarDetalleProveedorId(idProveedor);
        }

        public List<EntProveedorProducto> MostarDetalleProveedorId(int idProveedor)
        {
            return datProveedorProducto.Instancia.MostarDetalleProveedorId(idProveedor);
        }
        public List<EntProveedorProducto> BuscarProductoParaComprar(string busqueda)
        {
            return datProveedorProducto.Instancia.BuscarProductoParaComprar(busqueda);
        }

        public EntProveedorProducto BuscarProvedorProductoId(int idprod, int idprov)
        {
            return datProveedorProducto.Instancia.BuscarProvedorProductoId(idprod, idprov);
        }
        public bool EliminarDetalleProveedor(int prov, int prod)
        {
            return datProveedorProducto.Instancia.EliminarDetalleProveedor(prov, prod);
        }


    }
}
