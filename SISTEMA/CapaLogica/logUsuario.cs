using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
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
        public logUsuario()
        {
            
        }
        public logUsuario(IdatUsuario idataUsuario)
        {
            datusuarioInstancia = idataUsuario;
        }
        private IdatUsuario datusuarioInstancia;
        #region CLIENTES
        public bool CrearClientes(entUsuario c)
        {

            var error=string.Empty;
            var creado = false;
            var validado=ValidatorHelper.TryValidateEntity(c);
            try
            {
                if (validado)
                {
                   creado= datusuarioInstancia.CrearCliente(c);
                }
                else
                {
                    error = "El formato de entrada no coincide con la base de datos";
                    throw new Exception(error);
                }
                
            }
            catch(Exception e)
            {
                throw new Exception(error+" "+" detalles"+" "+ e.Message);
            }
            return creado;
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
        public List<entUsuario> BuscarAdministradores(string dato)
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
            var error=string.Empty;
            try
            {
                if (DateTime.Now.Hour > 24)
                {
                    error = "No puede ingresar a esta hora";
                    throw new Exception();
                }
                else
                {
                    u = datUsuario.Instacia.IniciarSesion(dato, contra);
                    if (u != null)
                    {
                        if (!u.Activo)
                        {
                            error = "Usuario ha sido dado de baja";
                            throw new Exception();
                        }

                    }
                    else
                    {
                        error = "usuario o contraseña incorrectos";
                        throw new Exception();
                    }

                }

            }
            catch {
                
                throw new Exception(error);
            }
            return u;
        }
        #endregion
    }
}
