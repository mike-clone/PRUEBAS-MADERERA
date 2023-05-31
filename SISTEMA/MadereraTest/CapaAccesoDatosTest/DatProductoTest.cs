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
        public void BuscarProductoPorNombre()
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
            Assert.That(buscado.Count, Is.EqualTo(2));
        }

        [Test]
        public void BuscarProductoPorNobre1()
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
        public void BuscarProductoPorTipo()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>
            {
                new EntProducto { IdProducto = 1,  Nombre = "Viga", Tipo = new EntTipoProducto{ Nombre = "Eucalipto"}},

                new EntProducto {IdProducto = 4, Nombre = "Mandallon", Tipo = new EntTipoProducto { Nombre = "Eucalipto"}}
            };
            mock.Setup(o => o.BuscarProducto("Eucalipto")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("Eucalipto");
            Assert.IsNotNull(buscado);
        }

        [Test]
        public void BuscarProductoNoExistente()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new List<EntProducto>();
            mock.Setup(o => o.BuscarProducto("ABC")).Returns(producto);
            var logProducto = new LogProducto(mock.Object);
            var buscado = logProducto.BuscarProducto("ABC");
            Assert.IsEmpty(buscado);
        }

        [Test]
        public void CrearProductocorrecto()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new EntProducto
            {
                IdProducto = 1,
                Nombre = "Nuevo",
                Diametro = 4.4,
                Longitud = 7,
                Tipo = new EntTipoProducto
                {
                    IdTipo_producto = 1,
                    Nombre = "Eucalipto"
                }
            };
            mock.Setup(o => o.CrearProducto(producto)).Returns(true);
            Exception? exception = null;
            var productoService = new LogProducto(mock.Object);
            bool result = false;
            try
            {
                result = productoService.CrearProducto(producto);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.Multiple(() =>
            {
                Assert.That(exception, Is.Null);
                Assert.That(result, Is.True);
            });
        }

        [Test]
        public void CrearProductoIncorrecto()
        {
            var mock = new Mock<IDatProducto>();
            var producto = new EntProducto
            {
                IdProducto = 1,
                Nombre = "Nuevo1",
                Diametro = 4.4,
                Longitud = 7,
                Tipo = new EntTipoProducto
                {
                    IdTipo_producto = 3,
                    Nombre = "Pino"
                }
            };
            mock.Setup(o => o.CrearProducto(producto)).Returns(false);
            Exception? exception = null;
            var productoService = new LogProducto(mock.Object);
            var result = true;
            try
            {
                result = productoService.CrearProducto(producto);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.That(result, Is.False);
        }
    }
}
