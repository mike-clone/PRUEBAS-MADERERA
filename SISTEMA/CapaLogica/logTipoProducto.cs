using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logTipoProducto
    {
        private static readonly logTipoProducto _instancia = new logTipoProducto();

        public static logTipoProducto Instancia
        {
            get { return _instancia; }
        }
        #region CRUD
        public bool CrearTipoProducto(entTipoProducto tipoProducto)
        {
            return datTipoProducto.Instancia.CrearTipoProducto(tipoProducto);
        }
        public List<entTipoProducto> SelectListTipoProducto()
        {
            return datTipoProducto.Instancia.SelectListTipoProducto();
        }
        public List<entTipoProducto> SelectListTipoProductodat(int id)
        {
            return datTipoProducto.Instancia.SelectListTipoProductodat(id);
        }
        public bool ActualizarTipoProducto(entTipoProducto tipoProducto)
        {
            return datTipoProducto.Instancia.ActualizarTipoProducto(tipoProducto);
        }
        public bool EliminarTipoProducto(int id)
        {
            return datTipoProducto.Instancia.EliminarTipoProducto(id);
        }

        #endregion CRUD
    }
}
