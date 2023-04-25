using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool EliminarTemporaryProducts(int id)
        {
            return DatTemporaryProducts.Instance.EliminarTemporaryProducts(id);
        }
        public bool ActualizarTemporaryProducts(EntTemporaryProducts temp)
        {
            return DatTemporaryProducts.Instance.ActualizarTemporaryProducts(temp);
        }
        public EntTemporaryProducts BuscarTemporaryProductsId(int idProveedor)
        {
            return DatTemporaryProducts.Instance.BuscarTemporaryProductsId(idProveedor);
        }
    }
}
