using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;


namespace CapaLogica
{
    public class logProducto
    {
        private static readonly logProducto _instancia = new logProducto();

        public static logProducto Instancia
        {
            get { return _instancia; }
        }
        #region Administrador
        public bool CrearProducto(entProducto prod)
        {
          bool validar= ValidatorHelper.TryValidateEntity(prod);

            return datProducto.Instancia.CrearProducto(prod);
        }
        public List<entProducto> ListarProducto()
        {
            return datProducto.Instancia.ListarProducto();
        }
        public bool ActualizarProducto(entProducto Prod)
        {
            return datProducto.Instancia.ActualizarProducto(Prod);
        }

        public bool EliminarProducto(int id)
        {
            return datProducto.Instancia.EliminarProducto(id);
        }
        public List<entProducto> BuscarProducto(string busqueda)
        {
            return datProducto.Instancia.BuscarProducto(busqueda);
        }
        public entProducto BuscarProductoId(int idprod)
        {
            return datProducto.Instancia.BuscarProductoId((int)idprod);
        }
        #endregion




    }
}
