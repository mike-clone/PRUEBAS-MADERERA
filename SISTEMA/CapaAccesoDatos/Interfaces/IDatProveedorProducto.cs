using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatProveedorProducto
    {
        bool CrearProveedorProducto(EntProveedorProducto prod);
        List<EntProveedorProducto> ListarProductoParaComprar();
        List<EntProveedorProducto> MostarDetalleProveedorId(int idProveedor);
        bool EliminarDetalleProveedor(int prov, int prod);
        List<EntProveedorProducto> BuscarProductoParaComprar(string busqueda);
        EntProveedorProducto BuscarProvedorProductoId(int idprod, int idprov);
    }
}
