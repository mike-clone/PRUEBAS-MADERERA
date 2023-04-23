using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<entProducto> ListarProducto()
        {
            return datProducto.Instancia.ListarProducto();
        }
        public List<entProducto> ListarProductoParaVender()
        {
            return datProducto.Instancia.ListarProductoParaVender();
        }
        public List<entProducto>BuscarProductoParaVender(string buscar)
        {
            return datProducto.Instancia.BuscarProductoParaVender(buscar);
        }
        public List<entProducto>Ordenar(int dato)
        {
            return datProducto.Instancia.Ordenar(dato);
        }
        public bool ActualizarProducto(entProducto prod)
        {
            return datProducto.Instancia.ActualizarProducto(prod);
        }
        public bool EliminarProducto(int id)
        {
            return datProducto.Instancia.EliminarProducto(id);
        }
        #endregion 

        public List<entProducto> BuscarProducto(string busqueda)
        {
            return datProducto.Instancia.BuscarProducto(busqueda);
        }

        public entProducto BuscarProductoId(int prod)
        {
            return datProducto.Instancia.BuscarProductoId(prod);
        }
    }
}
