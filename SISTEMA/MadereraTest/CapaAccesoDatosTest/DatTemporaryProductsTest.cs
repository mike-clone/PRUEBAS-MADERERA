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
    public class DatTemporaryProductsTest
    {
        [Test]
        public void AñadirCarritoCaso01()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            var producto = new EntTemporaryProducts
            {
                ProveedorProducto = new EntProveedorProducto
                {
                    Producto = new EntProducto
                    {
                        IdProducto = 10
                    }
                },
                Usuario = new EntUsuario
                {
                    IdUsuario = 4
                },
                Cantidad = 2,
                Subtotal = 14
            };
            mock.Setup(o => o.CreaarTemporaryProductsCli(producto)).Returns(true);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.CreaarTemporaryProductsCli(producto);
            Assert.That(agregado, Is.EqualTo(true));
        }

        [Test]
        public void AñadirCarritoCaso02()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            var producto = new EntTemporaryProducts
            {
                ProveedorProducto = new EntProveedorProducto
                {
                    Producto = new EntProducto
                    {
                        IdProducto = 20
                    }
                },
                Usuario = new EntUsuario
                {
                    IdUsuario = 7
                },
                Cantidad = 5,
                Subtotal = 30
            };
            mock.Setup(o => o.CreaarTemporaryProductsCli(producto)).Returns(true);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.CreaarTemporaryProductsCli(producto);
            Assert.That(agregado, Is.EqualTo(true));
        }

        [Test]
        public void AñadirCarritoCaso04()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            var producto = new EntTemporaryProducts
            {
                ProveedorProducto = new EntProveedorProducto
                {
                    Producto = new EntProducto
                    {
                        IdProducto = 10
                    }
                },
                Usuario = new EntUsuario
                {
                    IdUsuario = 4
                },
                Cantidad = 0,
                Subtotal = 0
            };
            mock.Setup(o => o.CreaarTemporaryProductsCli(producto)).Returns(false);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.CreaarTemporaryProductsCli(producto);
            Assert.That(agregado, Is.EqualTo(false));
        }

        [Test]
        public void EliminarProductoCarritoCaso01()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            mock.Setup(o => o.EliminarTemporaryProducts(4)).Returns(true);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.EliminarTemporaryProducts(4);
            Assert.That(agregado, Is.EqualTo(true));
        }

        [Test]
        public void EliminarProductoCarritoCaso02()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            mock.Setup(o => o.EliminarTemporaryProducts(10)).Returns(true);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.EliminarTemporaryProducts(10);
            Assert.That(agregado, Is.EqualTo(true));
        }

        [Test]
        public void EliminarProductoCarritoCaso03()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            mock.Setup(o => o.EliminarTemporaryProducts(0)).Returns(false);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var agregado = logtemporary.EliminarTemporaryProducts(0);
            Assert.That(agregado, Is.EqualTo(false));
        }

        [Test]
        public void MostrarCarritoCaso01()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            var productos = new List<EntTemporaryProducts>
            {
                new EntTemporaryProducts
                {
                    IdTemp = 1,
                    ProveedorProducto = new EntProveedorProducto
                    {
                        Producto = new EntProducto
                        {
                            IdProducto = 4,
                            Nombre = "Viga",
                            Longitud = 8,
                            Diametro = 5,
                            PrecioVenta = 25,
                            Tipo = new EntTipoProducto
                            {
                                Nombre = "Eucalipto"
                            }
                        }
                    },
                    Cantidad = 2,
                    Subtotal = 50
                }
                
            };
            mock.Setup(o => o.MostrarTemporaryProductsCli(2)).Returns(productos);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var mostrado = logtemporary.MostrarTemporaryProductsCli(2);
            Assert.IsNotNull(mostrado);
        }

        [Test]
        public void MostrarCarritoCaso02()
        {
            var mock = new Mock<IDatTemporaryProducts>();
            var productos = new List<EntTemporaryProducts>();
            mock.Setup(o => o.MostrarTemporaryProductsCli(4)).Returns(productos);
            var logtemporary = new LogTemporaryProducts(mock.Object);
            var mostrado = logtemporary.MostrarTemporaryProductsCli(4);
            Assert.IsEmpty(mostrado);
        }
    }
}
