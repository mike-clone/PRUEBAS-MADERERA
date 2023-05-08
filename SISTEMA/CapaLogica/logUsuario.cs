
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
namespace CapaLogica
{
    public class LogUsuario
    {
        public LogUsuario()
        {
            
        }
        private IDatUsuario UsuarioService;
        public LogUsuario(IDatUsuario IUsuario)
        {
            UsuarioService = IUsuario;
        }
        #region CLIENTES
        public bool CrearClientes(EntUsuario c)
        {

            var error=string.Empty;
            var creado = false;
            var validado=ValidatorHelper.TryValidateEntity(c);
            try
            {
                if (validado)
                {
                   creado= UsuarioService.CrearCliente(c);
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
        public List<EntUsuario> ListarClientes()
        {
            return UsuarioService.ListarCliente();
        }

        public List<EntUsuario> BuscarClientes(string dato)
        {
            return UsuarioService.BuscarCliente(dato);
        }

        public bool EliminarUsuarios(int id)
        {
            return UsuarioService.EliminarUsuarios(id);
        }

        public bool EditarCliente(EntUsuario u)
        {
            return UsuarioService.EditarCliente(u);
        }
        #endregion

        #region ADMINISTRADORES
        public List<EntUsuario> ListarAdministradores()
        {
            return UsuarioService.ListarAdministradores();
        }
        public bool ActualizarAdministrador(EntUsuario ad)
        {
            return UsuarioService.ActualizarAdministrador(ad);
        }
        public List<EntUsuario> BuscarAdministradores(string dato)
        {
            return UsuarioService.BuscaraAdministradores(dato);
        }
        #endregion


        #region COMPARTIDO
        public EntUsuario BuscarIdUsuario(int idCliente)
        {
            return UsuarioService.BuscarIdUsuario(idCliente);
        }

        public EntUsuario IniciarSesion(string dato, string contra)
        {
            EntUsuario u = null;
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
                    u = UsuarioService.IniciarSesion(dato, contra);
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
