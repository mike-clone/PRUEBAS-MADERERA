using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
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

        private IDatTemporaryProducts TemporaryService;

        public LogTemporaryProducts()
        {
            
        }

        public LogTemporaryProducts(IDatTemporaryProducts ITemporaryP)
        {
            TemporaryService = ITemporaryP;
        }

        public bool CreaarTemporaryProducts(EntTemporaryProducts temp)
        {
            return TemporaryService.CreaarTemporaryProducts(temp);
        }
        public bool CreaarTemporaryProductsCli(EntTemporaryProducts temp)
        {
            return TemporaryService.CreaarTemporaryProductsCli(temp);
        }

        public List<EntTemporaryProducts> MostrarTemporaryProducts(int idUsuario)
        {
            return TemporaryService.MostrarTemporaryProducts(idUsuario);
        }
        public List<EntTemporaryProducts> MostrarTemporaryProductsCli(int idUsuario)
        {
            return TemporaryService.MostrarTemporaryProductsCli(idUsuario);
        }
        public bool EliminarTemporaryProducts(int id)
        {
            return TemporaryService.EliminarTemporaryProducts(id);
        }
        public bool ActualizarTemporaryProducts(EntTemporaryProducts temp)
        {
            return TemporaryService.ActualizarTemporaryProducts(temp);
        }
        public EntTemporaryProducts BuscarTemporaryProductsId(int id)
        {
            return TemporaryService.BuscarTemporaryProductsId(id);
        }
        public EntTemporaryProducts BuscarTemporaryProductsIdCli(int id)
        {   
            return TemporaryService.BuscarTemporaryProductsIdCli(id);
        }
    }
}
