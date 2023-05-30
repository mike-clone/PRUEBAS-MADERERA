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
    public class DatVentaTest
    {
        [Test]
        public void MostrarVentaCaso01()
        {
            var mock = new Mock<IDatVenta>();
            var venta = new List<EntVenta>
            {
                new EntVenta 
                { 
                    Cliente = new EntUsuario
                    {
                        IdUsuario = 4
                    },
                    Fecha = new DateTime(2023,5,29),
                    Total = 45.5
                },
            };

            mock.Setup(o => o.ListarVenta(1)).Returns(venta);
            var logVenta = new LogVenta(mock.Object);
            var mostrado = logVenta.ListarVenta(1);
            Assert.IsNotNull(mostrado);
        }

        [Test]
        public void MostrarVentaCaso02()
        {
            var mock = new Mock<IDatVenta>();
            var venta = new List<EntVenta>
            {
                new EntVenta
                {
                    Cliente = new EntUsuario
                    {
                        IdUsuario = 6
                    },
                    Fecha = new DateTime(2023,5,29),
                    Total = 15
                },
            };

            mock.Setup(o => o.ListarVenta(3)).Returns(venta);
            var logVenta = new LogVenta(mock.Object);
            var mostrado = logVenta.ListarVenta(3);
            Assert.IsNotNull(mostrado);
        }

        [Test]
        public void MostrarVentaCaso03()
        {
            var mock = new Mock<IDatVenta>();
            var venta = new List<EntVenta>();

            mock.Setup(o => o.ListarVenta(5)).Returns(venta);
            var logVenta = new LogVenta(mock.Object);
            var mostrado = logVenta.ListarVenta(5);
            Assert.IsEmpty(mostrado);
        }
    }
}
