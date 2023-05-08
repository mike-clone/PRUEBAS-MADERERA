using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using CapaLogica;
using Moq;

namespace MadereraTest

{
    public class Tests
    {
       

        [Test]
        public void Test1()
        {
            var mock=new Mock<IDatUsuario>();

            EntUsuario us = new EntUsuario();
            mock.Setup(o => o.CrearCliente(us)).Returns(true);
            var logusurio = new LogUsuario(mock.Object);
           var creado= logusurio.CrearClientes(us);
            Assert.Pass();
        }
    }
}