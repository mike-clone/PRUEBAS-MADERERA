using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logProveedor
    {
        private static readonly logProveedor _instancia = new logProveedor();

        public static logProveedor Instancia
        {
            get { return _instancia; }
        }

        #region CRUD
        public bool CrearProveedor(EntProveedor pro)
        {
            return datProveedor.Instancia.CrearProveedor(pro);
        }
        public List<EntProveedor> ListarProveedor()
        {
            return datProveedor.Instancia.ListarProveedor();
        }
        public List<EntProveedor> SelectListProveedor()
        {
            return datProveedor.Instancia.SelectListProveedor();
        }
        public List<EntProveedor> SelectListProveedordat(int id)
        {
            
            return datProveedor.Instancia.SelectListProveedordat(id);
        }
        public bool ActualizarProveedor(EntProveedor pro)
        {
            return datProveedor.Instancia.ActualizarProveedor(pro);
        }
        public bool EliminarProveedor(int id)
        {
            return datProveedor.Instancia.EliminarProveedor(id);
        }
        #endregion CRUD

        public List<EntProveedor> BuscarProveedor(string busqueda)
        {
            return datProveedor.Instancia.BuscarProveedor(busqueda);
        }
        public EntProveedor BuscarIdProveedor(int idProveedor)
        {
            return datProveedor.Instancia.BuscarIdProveedor(idProveedor);
        }
    }
}
