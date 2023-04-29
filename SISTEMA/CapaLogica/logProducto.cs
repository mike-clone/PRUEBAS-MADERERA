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
        public int CrearProducto(entProducto prod)
        {
            return datProducto.Instancia.CrearProducto(prod);
        }
        public List<entProveedorProducto> ListarProducto()
        {
            return datProducto.Instancia.ListarProducto();
        }
        public List<entProducto> ListarProductoParaVender()
        {
            return datProducto.Instancia.ListarProductoParaVender();
        }
        public List<entProducto> BuscarProductoParaVender(string buscar)
        {
            return datProducto.Instancia.BuscarProductoParaVender(buscar);
        }
        public List<entProveedorProducto> Ordenar(int dato)
        {
            return datProducto.Instancia.Ordenar(dato);
        }
        public bool ActualizarProducto(entProveedorProducto prod)
        {
            return datProducto.Instancia.ActualizarProducto(prod);
        }
        public bool EliminarProducto(int id)
        {
            return datProducto.Instancia.EliminarProducto(id);
        }
        #endregion 

        public List<entProveedorProducto> BuscarProducto(string busqueda)
        {
            return datProducto.Instancia.BuscarProducto(busqueda);
        }

        public entProveedorProducto BuscarProductoId(int prod)
        {
            return datProducto.Instancia.BuscarProductoId(prod);
        }

        public entProveedorProducto BuscarProductoIdTemp(int idprod, int idprov)
        {
            return datProducto.Instancia.BuscarProductoIdTemp(idprod, idprov);
        }
    }
}
