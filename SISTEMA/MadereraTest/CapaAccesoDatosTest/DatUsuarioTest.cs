using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using CapaLogica;
using Moq;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace MadereraTest.CapaAccesoDatosTest
{
    public class DatUsuarioTest
    {
        [Test]
        public void IniciarSesionCorrectoRollAdministrador()
        {
            var mock = new Mock<IDatUsuario>();
            EntUsuario usuarioesperado1 = new() { UserName = "omar#225", RazonSocial = "omarindustries", Correo = "omar@industries.pe", Pass = "123", Activo = true, Rol = EntRol.Administrador };
            mock.Setup(o => o.IniciarSesion("omar@industries.pe", "123")).Returns(usuarioesperado1);
            Exception? exception = null;
            var usuarioService = new LogUsuario(mock.Object);
            var result = new EntUsuario();
            try
            {
                result = usuarioService.IniciarSesion("omar@industries.pe", "123");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.Multiple(() =>
            {
                Assert.That(exception, Is.Null);
                Assert.That(result, Is.EqualTo(usuarioesperado1));
            });
        }

        [Test]
        public void IniciarSesionCorrectoRollCliente()
        {
            var mock = new Mock<IDatUsuario>();
            EntUsuario usuarioesperado = new() { UserName = "omar#226", RazonSocial = "omarprojects", Correo = "omar@projects.pe", Pass = "123", Activo = true, Rol = EntRol.Cliente };
            mock.Setup(o => o.IniciarSesion("omar@projects.pe", "123")).Returns(usuarioesperado);
            Exception? exception = null;
            var usuarioService = new LogUsuario(mock.Object);
            var result = new EntUsuario();
            try
            {
                result = usuarioService.IniciarSesion("omar@projects.pe", "123");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.Multiple(() =>
            {
                Assert.That(exception, Is.Null);
                Assert.That(result, Is.EqualTo(usuarioesperado));
            });
        }

        [Test]
        public void IniciarSesionIncorrectoUsuariInactivo()
        {
            var mock = new Mock<IDatUsuario>();
            EntUsuario usuarioesperado = new() { UserName = "omar#226", RazonSocial = "omarprojects", Correo = "omar@projects.pe", Pass = "123", Activo = false, Rol = EntRol.Cliente };
            mock.Setup(o => o.IniciarSesion("omar@projects.pe", "123")).Returns(usuarioesperado);
            var usuarioService = new LogUsuario(mock.Object);
            Exception? exception = null;
            try
            {
               usuarioService.IniciarSesion("omar@projects.pe", "123");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Usuario ha sido dado de baja"));
         
        }

        [Test]
        public void IniciarSesionIncorrectoUsuarioNoExiste()
        {
            var mock = new Mock<IDatUsuario>();
            EntUsuario usuarioesperado = new() { UserName = "omar#226", RazonSocial = "omarprojects", Correo = "omar@projects.pe", Pass = "123", Activo = false, Rol = EntRol.Cliente };
            mock.Setup(o => o.IniciarSesion("omar@projects.pe", "123")).Returns(usuarioesperado);
            var usuarioService = new LogUsuario(mock.Object);
            Exception? exception = null;
            try
            {
                usuarioService.IniciarSesion("omar@projects.com", "123");
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
            Assert.That(exception.Message, Is.EqualTo("usuario o contraseña incorrectos"));


        }

        [Test]
        public void CrearUsuarioCorrecto()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Pass = "123",
                Correo = "carlos@gmail.com",
                Roll = new entRoll
                {
                    IdRoll = 3
                },
                Ubigeo = new EntUbigeo
                {
                    IdUbigeo = "010109"
                }
            };
            mock.Setup(o => o.CrearCliente(newusuario)).Returns(true);
            var logusurio = new LogUsuario(mock.Object);
            Exception? exception = null;
            bool creado = false;
            try
            {
                 creado = logusurio.CrearClientes(newusuario);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.That(exception, Is.Null);
            Assert.That(creado, Is.EqualTo(true));
        }

        [Test]
        public void CrearUsuarioIncorrectoFormatoCorreoIncorrecto()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Pass = "123",
                Correo = "email.example.com",
                Rol=EntRol.Administrador,
                Roll = new entRoll
                {
                    IdRoll = 3
                },
                Ubigeo = new EntUbigeo
                {
                    IdUbigeo = "010109"
                }
            };
            mock.Setup(o => o.CrearCliente(newusuario)).Returns(false);
            var usuarioService = new LogUsuario(mock.Object);
            Exception? exception = null;
            try
            {
                usuarioService.CrearClientes(newusuario);

            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Correo no es una dirección válida."));
           
        }
        [Test]
        public void CrearUsuarioIncorrectoUsuarioSinNombre()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                
                UserName = "carlos#1",
                Pass = "123",
                Correo = "error@gmail.com",
                Rol=EntRol.Cliente,
                Ubigeo = new EntUbigeo
                {
                    IdUbigeo = "010109"
                }
            };
            mock.Setup(o => o.CrearCliente(newusuario)).Returns(false);
            var usuarioService = new LogUsuario(mock.Object);
            Exception? exception = null;
            try
            {
                 usuarioService.CrearClientes(newusuario);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Razon Social no puede estar vacio."));
           
        }
        [Test]
        public void CrearUsuarioIncorrectoUsuarioSinPassword()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Correo = "calrlos@upn.pe",
                Rol = EntRol.Cliente,
                Ubigeo = new EntUbigeo
                {
                    IdUbigeo = "010109"
                }
            };
            mock.Setup(o => o.CrearCliente(newusuario)).Returns(false);
            var usuarioService = new LogUsuario(mock.Object);
            Exception? exception = null;
            try
            {
                usuarioService.CrearClientes(newusuario);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Password no puede estar vacio."));

        }
       
    }
}