using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatTipoProducto
    {
        bool CrearTipoProducto(EntTipoProducto tip);
        List<EntTipoProducto> SelectListTipoProducto();
        List<EntTipoProducto> SelectListTipoProductodat(int id);
        bool ActualizarTipoProducto(EntTipoProducto tip);
        bool EliminarTipoProducto(int id);
    }
}
