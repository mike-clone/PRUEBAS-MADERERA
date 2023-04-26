using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logEmpleado
    {
        private static readonly logEmpleado _instancia = new logEmpleado();

        public static logEmpleado Instancia
        {
            get { return _instancia; }
        }
        #region CRUD
        public bool CrearEmpleado(entEmpleado pro)
        {
            return datEmpleado.Instancia.CrearEmpleado(pro);
        }
        public List<entEmpleado> ListarEmpleado()
        {
            return datEmpleado.Instancia.ListarEmpleado();
        }
        public bool ActualizarEmpleado(entEmpleado pro)
        {
            return datEmpleado.Instancia.ActualizarEmpleado(pro);
        }
        public bool EliminarEmpleado(int id)
        {
            return datEmpleado.Instancia.EliminarEmpleado(id);
        }
        #endregion CRUD

        public List<entEmpleado> BuscarEmpleado(string busqueda)
        {
            return datEmpleado.Instancia.BuscarEmpleado(busqueda);
        }
        public entEmpleado BuscarIdEmpleado(int idEmpleado)
        {
            return datEmpleado.Instancia.BuscarIdEmpleado(idEmpleado);
        }
    }
}
