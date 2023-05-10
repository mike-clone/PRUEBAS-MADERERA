using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatVenta
    {
        int CrearVenta(EntVenta venta);
        List<EntVenta> ListarVenta(int id);
        List<EntVenta> ListarTodasLasVenta();
    }
}
