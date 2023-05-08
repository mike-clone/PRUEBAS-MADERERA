using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Interfaces
{
    public interface IDatUsuario
    {
        #region Cliente
        bool CrearCliente(EntUsuario Cli);
        List<EntUsuario> ListarCliente();
        List<EntUsuario> BuscarCliente(string busqueda);
        bool EditarCliente(EntUsuario u);
        #endregion
        #region Administradores
        List<EntUsuario> ListarAdministradores();
        bool ActualizarAdministrador(EntUsuario ad);
        List<EntUsuario> BuscaraAdministradores(string busqueda);

        #endregion
        #region compartido
        EntUsuario IniciarSesion(string campo, string contra);
        bool EliminarUsuarios(int id);
        EntUsuario BuscarIdUsuario(int busqueda);
        #endregion
    }
}
