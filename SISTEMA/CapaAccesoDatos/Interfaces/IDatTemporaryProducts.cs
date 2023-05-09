using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatTemporaryProducts
    {
        bool CreaarTemporaryProductsCli(EntTemporaryProducts temp);
        bool CreaarTemporaryProducts(EntTemporaryProducts temp);
        List<EntTemporaryProducts> MostrarTemporaryProducts(int idUsuario);
        List<EntTemporaryProducts> MostrarTemporaryProductsCli(int idUsuario);
        bool EliminarTemporaryProducts(int idtemp);
        bool ActualizarTemporaryProducts(EntTemporaryProducts temp);
        EntTemporaryProducts BuscarTemporaryProductsId(int id);
        EntTemporaryProducts BuscarTemporaryProductsIdCli(int id);
    }
}
