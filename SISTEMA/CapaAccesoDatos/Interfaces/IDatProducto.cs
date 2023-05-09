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
        bool CrearProducto(entProducto prod);
        List<entProducto> ListarProducto();
        bool ActualizarProducto(entProducto Prod);
        bool EliminarProducto(int id);
        List<entProducto> BuscarProducto(string busqueda);
        entProducto BuscarProductoId(int idprod);
        List<entProveedorProducto> Ordenar(int dato);
    }
}
