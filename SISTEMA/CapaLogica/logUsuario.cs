using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogica
{
    public class logUsuario
    {
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia
        {
            get { return _instancia; }
        }
        #region CLIENTES
        public bool CrearClientes(entUsuario c)
        {
            return datUsuario.Instacia.CrearCliente(c);
        }
        public List<entUsuario> ListarClientes()
        {
            return datUsuario.Instacia.ListarCliente();
        }

        public List<entUsuario> BuscarClientes(string dato)
        {
            return datUsuario.Instacia.BuscarCliente(dato);
        }

        public bool EliminarUsuarios(int id)
        {
            return datUsuario.Instacia.EliminarUsuarios(id);
        }

        public bool EditarCliente(entUsuario u)
        {
            return datUsuario.Instacia.EditarCliente(u);
        }
        #endregion

        #region ADMINISTRADORES
        public List<entUsuario> ListarAdministradores()
        {
            return datUsuario.Instacia.ListarAdministradores();
        }
        public bool ActualizarAdministrador(entUsuario ad)
        {
            return datUsuario.Instacia.ActualizarAdministrador(ad);
        }
        public List<entUsuario>BuscarAdministradores(string dato)
        {
            return datUsuario.Instacia.BuscaraAdministradores(dato);
        }
        #endregion
       

        #region COMPARTIDO
        public entUsuario BuscarIdUsuario(int idCliente)
        {
            return datUsuario.Instacia.BuscarIdUsuario(idCliente);
        }

        public entUsuario IniciarSesion(string dato, string contra)
        {
            entUsuario u = null;
            try
            {
                if (DateTime.Now.Hour > 24)
                {
                    throw new ApplicationException("No puede ingresar a esta hora");
                }
                else
                {
                    u = datUsuario.Instacia.IniciarSesion(dato, contra);
                    if (u != null)
                    {
                        if (!u.Activo)
                        {
                            throw new ApplicationException("Usuario ha sido dado de baja");
                        }

                    }
                    else
                    {
                        throw new ApplicationException("Datos invalidos");
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            return u;
        }
        #endregion
    }
}
