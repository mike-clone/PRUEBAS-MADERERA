using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatProducto
    {
        bool CrearProducto(EntProducto prod);
        List<EntProducto> ListarProducto();
        bool ActualizarProducto(EntProducto Prod);
        bool EliminarProducto(int id);
        List<EntProducto> BuscarProducto(string busqueda);
        EntProducto BuscarProductoId(int idprod);
        List<entProveedorProducto> Ordenar(int dato);
    }
}
