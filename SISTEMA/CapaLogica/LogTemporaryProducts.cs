using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogTemporaryProducts
    {
        public static readonly LogTemporaryProducts _instance = new LogTemporaryProducts();

        public static LogTemporaryProducts Instancia
        {
            get { return _instance; }
        }

        public bool CreaarTemporaryProducts(EntTemporaryProducts temp)
        {
            return DatTemporaryProducts.Instance.CreaarTemporaryProducts(temp);
        }

        public List<EntTemporaryProducts> MostrarTemporaryProducts(int idUsuario)
        {
            return DatTemporaryProducts.Instance.MostrarTemporaryProducts(idUsuario);
        }
        public List<EntTemporaryProducts> MostrarTemporaryProductsCli(int idUsuario)
        {
            return DatTemporaryProducts.Instance.MostrarTemporaryProductsCli(idUsuario);
        }
        public bool EliminarTemporaryProducts(int id)
        {
            return DatTemporaryProducts.Instance.EliminarTemporaryProducts(id);
        }
        public bool ActualizarTemporaryProducts(EntTemporaryProducts temp)
        {
            return DatTemporaryProducts.Instance.ActualizarTemporaryProducts(temp);
        }
        public EntTemporaryProducts BuscarTemporaryProductsId(int id)
        {
            return DatTemporaryProducts.Instance.BuscarTemporaryProductsId(id);
        }
    }
}
