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
        public bool CrearTipoProducto(EntTipoProducto tipoProducto)
        {
            return datTipoProducto.Instancia.CrearTipoProducto(tipoProducto);
        }
        public List<EntTipoProducto> SelectListTipoProducto()
        {
            return datTipoProducto.Instancia.SelectListTipoProducto();
        }
        public List<EntTipoProducto> SelectListTipoProductodat(int id)
        {
            return datTipoProducto.Instancia.SelectListTipoProductodat(id);
        }
        public bool ActualizarTipoProducto(EntTipoProducto tipoProducto)
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
