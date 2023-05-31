using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using CapaLogica;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadereraTest.CapaAccesoDatosTest
{
    public class DatProveedorTest
    {
        [Test]
        public void TestListarProveedores()
        {
            var mock = new Mock<IDatProveedor>();
            var lista = new List<EntProveedor>
            {
                new EntProveedor { RazonSocial = "MaderaCompani" },
                new EntProveedor { RazonSocial = "MaderaCompani1" }
            };
            mock.Setup(m => m.ListarProveedor()).Returns(lista);
            Exception? exeption = null;
            var proveedorService = new LogProveedor(mock.Object);
            var listaProveedores = new List<EntProveedor>();
            try
            {
                listaProveedores = proveedorService.ListarProveedor();
            }
            catch (Exception e)
            {
                exeption = e;
            }
            Assert.IsNull(exeption);
            Assert.That(listaProveedores, Has.Count.EqualTo(2));
        }
        [Test]
        public void TestBuscarProveedorPorRazonSocial()
        {
            var mock = new Mock<IDatProveedor>();
            var lista = new List<EntProveedor>
            {
                new EntProveedor { RazonSocial = "MaderaCompani" },
                new EntProveedor { RazonSocial = "MaderaCompanicopia" }
            };
            mock.Setup(m => m.BuscarProveedor("MaderaCompani")).Returns(lista);
            Exception? exeption = null;
            var proveedorService = new LogProveedor(mock.Object);
            var listaProveedores = new List<EntProveedor>();
            try
            {
                listaProveedores = proveedorService.BuscarProveedor("MaderaCompani");
            }
            catch (Exception e)
            {
                exeption = e;
            }
            Assert.IsNull(exeption);
            Assert.That(listaProveedores, Has.Count.EqualTo(2));
        }
        [Test]
        public void TestBuscarProveedorPorEmail()
        {
            var mock = new Mock<IDatProveedor>();
            var lista = new List<EntProveedor>
            {
                new EntProveedor { RazonSocial = "MaderaCompani",Correo="email1"},
                new EntProveedor { RazonSocial = "MaderaCompanicopia",Correo="email2" }
            };
            mock.Setup(m => m.BuscarProveedor("email1")).Returns(lista);
            Exception? exeption = null;
            var proveedorService = new LogProveedor(mock.Object);
            var listaProveedores = new List<EntProveedor>();
            try
            {
                listaProveedores = proveedorService.BuscarProveedor("email1");
            }
            catch (Exception e)
            {
                exeption = e;
            }
            Assert.IsNull(exeption);
            Assert.That(listaProveedores, Has.Count.EqualTo(2));
        }
        [Test]
        public void TestBuscarProveedorPorTelefono()
        {
            var mock = new Mock<IDatProveedor>();
            var lista = new List<EntProveedor>
            {
                new EntProveedor { RazonSocial = "MaderaCompani",Telefono="telefono1"},
                new EntProveedor { RazonSocial = "MaderaCompanicopia",Telefono="telefono2" }
            };
            mock.Setup(m => m.BuscarProveedor("telefono1")).Returns(lista);
            Exception? exeption = null;
            var proveedorService = new LogProveedor(mock.Object);
            var listaProveedores = new List<EntProveedor>();
            try
            {
                listaProveedores = proveedorService.BuscarProveedor("telefono1");
            }
            catch (Exception e)
            {
                exeption = e;
            }
            Assert.IsNull(exeption);
            Assert.That(listaProveedores, Has.Count.EqualTo(2));
        }
        [Test]
        public void TestCrearProveedor()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "email1@gamil",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(true);
            Exception? exeption = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exeption = e;
            }

            Assert.Multiple(() =>
            {
                Assert.That(exeption, Is.Null);
                Assert.That(resultado, Is.True);
            });
        }
        [Test]
        public void TestCrearproveedorIncorrectoEmail()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "email1",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Correo no es una dirección válida."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestCrearproveedorIncorrectoTelefono()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "madera@gamil.com",
                Telefono = "1234567891",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Teléfono debe tener 9 dígitos y comenzar con 9."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestCrearProveedorIncorrectoSinEmail()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Email es obligatorio."));
                Assert.That(resultado, Is.False);
            });

        }
        [Test]
        public void TestCrearproveedorIncorrectoSinRuc()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "correo@gmai.com",
                Telefono = "923456789",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Ruc es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestCrearproveedorIncorrectoSinRazonSocial()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                Correo = "correo@outlook.es",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Razon Social es obligatorio."));
                Assert.That(resultado, Is.False);
            });
                
        }
        [Test]
        public void TestCrearproveedorIncorrectoSinDescripcion()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "correo@gamail.com",
                Telefono = "923456789",
                Ruc = "12345678910"
            };
            mock.Setup(m => m.CrearProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.CrearProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Descripcion es obligatorio."));
                Assert.That(resultado, Is.False);
            });

        }
        [Test]
        public void TestEditarProveedor()
        {
            Mock<IDatProveedor> mock = new Mock<IDatProveedor>();
            EntProveedor proveedor = new()
            {
                RazonSocial = "MaderaCompani",
                Correo = "correo@gamail.com",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(true);
            Exception? exception = null;
            LogProveedor proveedorService = new(mock.Object);
            bool resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Null);
            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.True);
            });

        }
        [Test]
        public void TestEditarProveedorIncorrectoEmailIncorrecto()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "email.example.com",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Email no es una dirección válida."));
                Assert.That(resultado, Is.False);
            });

        }
        [Test]
        public void TestEditarProveedorIncorrectoSinTelefono()
        {
            var mock = new Mock<IDatProveedor>();
            var proveedor = new EntProveedor
            {
                RazonSocial = "MaderaCompani",
                Correo = "email@exameple.com",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            var proveedorService = new LogProveedor(mock.Object);
            var resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Telefono es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestEditarProveedorIncorrectoSinEmail()
        {
            Mock<IDatProveedor> Mock= new Mock<IDatProveedor>();
            EntProveedor proveedor = new()
            {
                RazonSocial = "MaderaCompani",
                //Correo = "correo@gamail.com",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
                
            };
            Mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            LogProveedor proveedorService = new(Mock.Object);
            bool resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Email es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestEditarProveedorIncorrectoSinRuc()
        {
            Mock<IDatProveedor> Mock = new Mock<IDatProveedor>();
            EntProveedor proveedor = new()
            {
                RazonSocial = "MaderaCompani",
                Correo = "email@.exameple.com",
                Telefono = "923456789",
                //Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            Mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            LogProveedor proveedorService = new(Mock.Object);
            bool resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Ruc es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestEditarProveedorIncorrectoSinRazonSocial()
        {
            Mock<IDatProveedor> Mock = new Mock<IDatProveedor>();
            EntProveedor proveedor = new()
            {
                //RazonSocial = "MaderaCompani",
                Correo = "email@.exameple.com",
                Telefono = "923456789",
                Ruc = "12345678910",
                Descripcion = "Proveedor de madera"
            };
            Mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            LogProveedor proveedorService = new(Mock.Object);
            bool resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Razon Social es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
        [Test]
        public void TestEditarProveedorIncorrectoSinDescripcion()
        {
            Mock<IDatProveedor> Mock = new Mock<IDatProveedor>();
            EntProveedor proveedor = new()
            {
                RazonSocial = "MaderaCompani",
                Correo = "email@.exameple.com",
                Telefono = "923456789",
                Ruc = "12345678910",
                //Descripcion = "Proveedor de madera"
            };
            Mock.Setup(m => m.ActualizarProveedor(proveedor)).Returns(false);
            Exception? exception = null;
            LogProveedor proveedorService = new(Mock.Object);
            bool resultado = false;
            try
            {
                resultado = proveedorService.ActualizarProveedor(proveedor);
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Uno o mas parametros estan vacios \nEs probale que :\n El campo Descripcion es obligatorio."));
                Assert.That(resultado, Is.False);
            });
        }
    }
}
