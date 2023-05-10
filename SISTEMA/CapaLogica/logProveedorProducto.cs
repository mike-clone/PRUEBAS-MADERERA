using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{

    public class LogProveedorProducto
    {
        private static readonly LogProveedorProducto _instancia = new LogProveedorProducto();
        public static LogProveedorProducto Instancia
        {
            get { return _instancia; }
        }

        private IDatProveedorProducto ProveedorProductoService;

        public LogProveedorProducto()
        {
            
        }

        public LogProveedorProducto(IDatProveedorProducto IProveedorProducto)
        {
            ProveedorProductoService = IProveedorProducto;
        }

        public bool CrearProveedorProducto(EntProveedorProducto prod)
        {
            return ProveedorProductoService.CrearProveedorProducto(prod);

        }
        public List<EntProveedorProducto> ListarProductoParaComprar()
        {
            return ProveedorProductoService.ListarProductoParaComprar();
        }

        public List<EntProveedorProducto> MostrarDetalleProvedorId(int idProveedor)
        {
            return ProveedorProductoService.MostarDetalleProveedorId(idProveedor);
        }

        public List<EntProveedorProducto> MostarDetalleProveedorId(int idProveedor)
        {
            return ProveedorProductoService.MostarDetalleProveedorId(idProveedor);
        }
        public List<EntProveedorProducto> BuscarProductoParaComprar(string busqueda)
        {
            return ProveedorProductoService.BuscarProductoParaComprar(busqueda);
        }

        public EntProveedorProducto BuscarProvedorProductoId(int idprod, int idprov)
        {
            return ProveedorProductoService.BuscarProvedorProductoId(idprod, idprov);
        }
        public bool EliminarDetalleProveedor(int prov, int prod)
        {
            return ProveedorProductoService.EliminarDetalleProveedor(prov, prod);
        }


    }
}
