using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using CapaLogica;
using Moq;
using System.Runtime.CompilerServices;

namespace MadereraTest.CapaAccesoDatosTest
{
    public class DatUsuarioTest
    {

        [Test]
        public void CrearUsuarioCorrecto()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Pass = "123",
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
            var creado = logusurio.CrearClientes(newusuario);
            Assert.That(creado, Is.EqualTo(true));
        }

        [Test]
        public void CrearUsuarioIncorrecto()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Pass = "123",
                Roll = new entRoll
                {
                    IdRoll = 3
                },
                Ubigeo = new EntUbigeo
                {
                    IdUbigeo = "010109457755"
                }
            };
            mock.Setup(o => o.CrearCliente(newusuario)).Returns(false);
            var logusurio = new LogUsuario(mock.Object);
            var creado = logusurio.CrearClientes(newusuario);
            Assert.That(creado, Is.EqualTo(false));
        }
        [Test]
        public void CrearUsuarioIncorrecto2()
        {
            var mock = new Mock<IDatUsuario>();
            var newusuario = new EntUsuario
            {
                RazonSocial = "carlos",
                UserName = "carlos#1",
                Pass = "123r",
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
            var logusurio = new LogUsuario(mock.Object);
            var creado = logusurio.CrearClientes(newusuario);
            Assert.That(creado, Is.EqualTo(false));
        }
    }
}