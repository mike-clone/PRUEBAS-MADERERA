using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogProveedor
    {
        private static readonly LogProveedor _instancia = new LogProveedor();

        public static LogProveedor Instancia
        {
            get { return _instancia; }
        }
        private IDatProveedor ProveedorService;

        public LogProveedor()
        {
            
        }

        public LogProveedor(IDatProveedor IProveedor)
        {
            ProveedorService = IProveedor;
        }
        #region CRUD
        public bool CrearProveedor(EntProveedor pro)
        {
            return ProveedorService.CrearProveedor(pro);
        }
        public List<EntProveedor> ListarProveedor()
        {
            return ProveedorService.ListarProveedor();
        }
        public List<EntProveedor> SelectListProveedor()
        {
            return ProveedorService.SelectListProveedor();
        }
        public List<EntProveedor> SelectListProveedordat(int id)
        {
            
            return ProveedorService.SelectListProveedordat(id);
        }
        public bool ActualizarProveedor(EntProveedor pro)
        {
            return ProveedorService.ActualizarProveedor(pro);
        }
        public bool EliminarProveedor(int id)
        {
            return ProveedorService.EliminarProveedor(id);
        }
        #endregion CRUD

        public List<EntProveedor> BuscarProveedor(string busqueda)
        {
            return ProveedorService.BuscarProveedor(busqueda);
        }
        public EntProveedor BuscarIdProveedor(int idProveedor)
        {
            return ProveedorService.BuscarIdProveedor(idProveedor);
        }
    }
}
