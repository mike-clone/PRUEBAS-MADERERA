using CapaEntidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatDetCompra
    {
        bool CrearDetCompra(EntDetCompra Det);
        List<EntDetCompra> MostrarDetalleCompraId(int id);
        
    }
}
