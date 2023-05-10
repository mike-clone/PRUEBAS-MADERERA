using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogTipoProducto
    {
        private static readonly LogTipoProducto _instancia = new LogTipoProducto();

        public static LogTipoProducto Instancia
        {
            get { return _instancia; }
        }

        private IDatTipoProducto TipoProductoService;

        public LogTipoProducto()
        {
            
        }

        public LogTipoProducto(IDatTipoProducto ITipoProducto)
        {
            TipoProductoService = ITipoProducto;
        }

        #region CRUD
        public bool CrearTipoProducto(EntTipoProducto tipoProducto)
        {
            return TipoProductoService.CrearTipoProducto(tipoProducto);
        }
        public List<EntTipoProducto> SelectListTipoProducto()
        {
            return TipoProductoService.SelectListTipoProducto();
        }
        public List<EntTipoProducto> SelectListTipoProductodat(int id)
        {
            return TipoProductoService.SelectListTipoProductodat(id);
        }
        public bool ActualizarTipoProducto(EntTipoProducto tipoProducto)
        {
            return TipoProductoService.ActualizarTipoProducto(tipoProducto);
        }
        public bool EliminarTipoProducto(int id)
        {
            return TipoProductoService.EliminarTipoProducto(id);
        }

        #endregion CRUD
    }
}
