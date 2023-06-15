using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;
namespace CapaLogica
{

    public class LogUbigeo
    {
        private static readonly LogUbigeo _instancia = new LogUbigeo();
        private IDatUbigeo UbigeoService;
        public static LogUbigeo Instancia
        {
            get { return _instancia; }
        }
        public LogUbigeo()
        {
            
        }
        public LogUbigeo(IDatUbigeo IUbigeo)
        {
            UbigeoService = IUbigeo;
        }

        public bool CrearUbigeo(EntUbigeo u)
        {
            return UbigeoService.CrearUbigeo(u);
        }
        public List<EntUbigeo> ListarUbigeo()
        {
            return UbigeoService.ListarUbigeo();
        }
        public bool ActualizarUbigeo(EntUbigeo u)
        {
            return UbigeoService.ActualizarUbigeo(u);
        }
        public bool EliminarUbigeo(int id)
        {
            return UbigeoService.EliminarUbigeo(id);
        }
        public List<EntUbigeo> ListarDistrito()
        {
            return UbigeoService.ListarDistrito();
        }
        public List<EntUbigeo> BuscarUbigeo(string busqueda)
        {
            return UbigeoService.BuscarUbigeo(busqueda);
        }

    }
}
