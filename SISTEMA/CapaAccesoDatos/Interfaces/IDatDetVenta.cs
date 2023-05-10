using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatDetVenta
    {
        bool CrearDetVenta(EntDetVenta Det);
        List<EntDetVenta> Mostrardetventa(int idVenta);
    }
}
