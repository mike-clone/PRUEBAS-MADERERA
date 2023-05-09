using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatUbigeo
    {
        bool CrearUbigeo(EntUbigeo ubi);
        List<EntUbigeo> ListarUbigeo();
        List<EntUbigeo> ListarDistrito();
        bool ActualizarUbigeo(EntUbigeo ubi);
        bool EliminarUbigeo(int id);
        List<EntUbigeo> BuscarUbigeo(string busqueda);
    }
}
