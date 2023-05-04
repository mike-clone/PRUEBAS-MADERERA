using CapaAccesoDatos;
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
            var mock=new Mock<IdatUsuario>();

            entUsuario us = new entUsuario();
            mock.Setup(o => o.CrearCliente(us)).Returns(true);
            var logusurio = new logUsuario(mock.Object);
           var creado= logusurio.CrearClientes(us);
            Assert.Pass();
        }
    }
}