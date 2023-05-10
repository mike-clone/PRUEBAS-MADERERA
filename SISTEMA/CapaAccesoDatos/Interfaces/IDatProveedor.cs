using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatProveedor
    {
        bool CrearProveedor(EntProveedor pro);
        List<EntProveedor> ListarProveedor();
        List<EntProveedor> SelectListProveedor();
        bool ActualizarProveedor(EntProveedor pro);
        bool EliminarProveedor(int idProveedor);
        List<EntProveedor> SelectListProveedordat(int idprov);
        List<EntProveedor> BuscarProveedor(string busqueda);
        EntProveedor BuscarIdProveedor(int idProveedor);
    }
}
