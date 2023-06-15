
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapaLogica
{
    public class LogUsuario
    {
        private readonly IDatUsuario UsuarioService;

        public LogUsuario()
        {
            
        }
        public LogUsuario(IDatUsuario IUsuario)
        {
            UsuarioService = IUsuario;
        }
        #region CLIENTES
        public bool CrearClientes(EntUsuario usuario)
        {

            var error=string.Empty;
            bool isValid = ValidatorHelper.TryValidateEntity(usuario, out List<string> detalleDeError);
            var detalleerrors = ValidatorHelper.aString(detalleDeError);
            bool creado = false;
            try
            {
                if (isValid)
                {
                  creado= UsuarioService.CrearCliente(usuario);
                }
                else
                {
                    error = "Uno o mas parametros estan vacios";
                    throw new Exception(error);
                }
                
            }
            catch(Exception e)
            {
                throw new Exception( e.Message
                                    + " "
                                    + "\n"
                                    + "Es probale que :"
                                    + "\n"
                                    + " "
                                    + detalleerrors);
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
