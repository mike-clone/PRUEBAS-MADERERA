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
        #region CRUD
        public bool CrearCliente(entUsuario c)
        {
            return datUsuario.Instacia.CrearCliente(c);
        }
        public List<entUsuario> ListarCliente()
        {
            return datUsuario.Instacia.ListarCliente();
        }
        public bool ActualizarCliente(entUsuario c)
        {
            return datUsuario.Instacia.ActualizarCliente(c);
        }
        public bool EliminarCliente(int id)
        {
            return datUsuario.Instacia.EliminarCliente(id);
        }
        #endregion CRUD

        public List<entUsuario> BuscarCliente(string dato)
        {
            return datUsuario.Instacia.BuscarCliente(dato);
        }
        public entUsuario BuscarIdCliente(int idCliente)
        {
            return datUsuario.Instacia.BuscarIdCliente(idCliente);
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
    }
}
