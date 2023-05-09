using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;


namespace CapaLogica
{
    public class LogProducto
    {
        private static readonly LogProducto _instancia = new LogProducto();

        public static LogProducto Instancia
        {
            get { return _instancia; }
        }

        private IDatProducto ProductoService;

        public LogProducto()
        {
            
        }

        public LogProducto(IDatProducto IProducto)
        {
            ProductoService = IProducto;
        }

        #region Administrador
        public bool CrearProducto(entProducto prod)
        {
            bool validar= ValidatorHelper.TryValidateEntity(prod);
            return ProductoService.CrearProducto(prod);
        }
        public List<entProducto> ListarProducto()
        {
            return ProductoService.ListarProducto();
        }
        public bool ActualizarProducto(entProducto Prod)
        {
            return ProductoService.ActualizarProducto(Prod);
        }

        public bool EliminarProducto(int id)
        {
            return ProductoService.EliminarProducto(id);
        }
        public List<entProducto> BuscarProducto(string busqueda)
        {
            return ProductoService.BuscarProducto(busqueda);
        }
        public entProducto BuscarProductoId(int idprod)
        {
            return ProductoService.BuscarProductoId((int)idprod);
        }
        #endregion




    }
}
