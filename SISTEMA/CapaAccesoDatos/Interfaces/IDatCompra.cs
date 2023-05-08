using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatCompra
    {
        
        int CrearCompra(EntCompra comp);
         List<EntCompra> ListarCompra(int id);
         List<EntCompra> ListarTodasLasCompras();
         bool EliminarCompra(int idcompra);
         List<EntCompra> BuscarCompra(string busqueda);
        
    }
}
