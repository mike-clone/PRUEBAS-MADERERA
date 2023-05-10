using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{

    [Authorize]
    [PermisosRol(entRol.Administrador)]
    public class CompraController : Controller
    {
        LogCompra CompraService;
        LogDetCompra DetCompraService;
        LogVenta Ventaservice;
        LogTemporaryProducts TemporaryPservice;

        public CompraController()
        {
            CompraService = new LogCompra(new DatCompra());
            DetCompraService = new LogDetCompra(new DatDetCompra());
            TemporaryPservice = new LogTemporaryProducts(new DatTemporaryProducts());
            Ventaservice = new LogVenta(new DatVenta());
        }
    
        // GET: Compra
        public ActionResult ListarCompra()
        {
            _ = new EntUsuario();
            EntUsuario usuario = Session["Usuario"] as EntUsuario;
            return View(CompraService.ListarCompra(usuario.IdUsuario));
        }

        public ActionResult ListarTodasLasCompras()
        {
            return View(CompraService.ListartodasLasCompras());
        }

        public ActionResult ListarTodasLasVentas()
        {
            return View(Ventaservice.ListarTodasLasVenta());
        }

        public ActionResult ConfirmarCompra()
        {
            try
            {
                //obtenemos el usuario que esta realizando la compra
                EntUsuario usuario=new EntUsuario();
                usuario = Session["Usuario"] as EntUsuario;
                //Obtenemos los productos temprales del usuario que estan en el carrito
                List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
                list = TemporaryPservice.MostrarTemporaryProducts(usuario.IdUsuario);
                
                //calculamos el total
                double total = 0;
                for (int i = 0; i <list.Count(); i++)
                {
                    total +=list[i].Subtotal;
                }
                //CREAMOS EL PEDIDO
                EntCompra Pedido = new EntCompra
                {
                    Usuario = usuario,
                    Total = total
                };

                //Obtenemos el id del pedido  creada
                int idCompra = CompraService.CrearCompra(Pedido);
                //seteamos el id delpedido
                Pedido.IdCompra = idCompra;

                EntDetCompra det = new EntDetCompra();
                for (int i = 0; i <list.Count; i++)
                {
                    det.Compra = Pedido;
                    det.ProveedorProducto = new EntProveedorProducto
                    {
                        Proveedor = new EntProveedor
                        {
                            IdProveedor = list[i].ProveedorProducto.Proveedor.IdProveedor
                        },
                        Producto=new EntProducto
                        {
                            IdProducto = list[i].ProveedorProducto.Producto.IdProducto
                        }
                    };
                    det.Cantidad = list[i].Cantidad;
                    det.Subtotal = list[i].Subtotal;
                   
                    DetCompraService.CrearDetCompra(det);
                }
                return RedirectToAction("ListarCompra");

            }
            catch
            {
                return RedirectToAction("Error","Home");

            }
        }

        public ActionResult MostrarDetalleCompra( int idcompra)
        {
            return View(DetCompraService.MostrarDetalleCompraId(idcompra));
        }
    }
}