using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using CapaLogica;
using Moq;
using System.Threading.Tasks;

namespace MadereraTest.CapaAccesoDatosTest
{
    public class DatProductoTest
    {
        [Test]
        public void BuscarProductoCaso01()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>
            {
                new EntProducto { IdProducto = 1, Nombre = "Viga", Diametro = 4},
                new EntProducto { IdProducto = 2, Nombre = "Viga", Diametro = 2}
            };

            mock.Setup(o => o.BuscarProducto("Viga")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("Viga");
            Assert.IsNotNull(buscado);
        }

        [Test]
        public void BuscarProductoCaso02()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>
            {
                new EntProducto { IdProducto = 1, Nombre = "Mandallon", Diametro = 5},
            };

            mock.Setup(o => o.BuscarProducto("Mandallon")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("Mandallon");
            Assert.IsNotNull(buscado);
        }

        [Test]
        public void BuscarProductoCaso03()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>
            {
                new EntProducto 
                { 
                    IdProducto = 1, 
                    Nombre = "Viga", 
                    Tipo = new EntTipoProducto 
                    { 
                        Nombre = "Eucalipto"
                    }
                },

                new EntProducto
                {
                    IdProducto = 4,
                    Nombre = "Mandallon",
                    Tipo = new EntTipoProducto
                    {
                        Nombre = "Eucalipto"
                    }
                }
            };

            mock.Setup(o => o.BuscarProducto("Eucalipto")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("Eucalipto");
            Assert.IsNotNull(buscado);
        }

        [Test]
        public void BuscarProductoCaso04()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>();
            mock.Setup(o => o.BuscarProducto("ABC")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("ABC");
            Assert.IsEmpty(buscado);
        }
    }
}
