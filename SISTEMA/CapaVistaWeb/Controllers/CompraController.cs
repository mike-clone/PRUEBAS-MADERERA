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

        // GET: Compra
        public ActionResult ListarCompra()
        {
            List<entCompra> lsCompra = logCompra.Instancia.ListarCompra();
            return View(lsCompra);
        }


    
        public ActionResult ConfirmarCompra()
        {
            try
            {
                //obtenemos el usuario que esta realizando la compra
                entUsuario usuario=new entUsuario();
                usuario = Session["Usuario"] as entUsuario;
                //Obtenemos los productos temprales del usuario que estan en el carrito
                List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
                list = LogTemporaryProducts.Instancia.MostrarTemporaryProducts(usuario.IdUsuario);
                
                //calculamos el total
                double total = 0;
                for (int i = 0; i <list.Count(); i++)
                {
                    total +=list[i].Subtotal;
                }
                //CREAMOS EL PEDIDO
                entCompra Pedido = new entCompra
                {
                    Usuario = usuario,
                    Total = total
                };

                //Obtenemos el id del pedido  creada
                int idCompra = logCompra.Instancia.CrearCompra(Pedido);
                //seteamos el id delpedido
                Pedido.IdCompra = idCompra;

                entDetCompra det = new entDetCompra();
                for (int i = 0; i <list.Count; i++)
                {
                    det.Compra = Pedido;
                    det.ProveedorProducto = new entProveedorProducto
                    {
                        Proveedor = new entProveedor
                        {
                            IdProveedor = list[i].ProveedorProducto.Proveedor.IdProveedor
                        },
                        Producto=new entProducto
                        {
                            IdProducto = list[i].ProveedorProducto.Producto.IdProducto
                        }
                    };
                    det.Cantidad = list[i].Cantidad;
                    det.Subtotal = list[i].Subtotal;
                   
                    logDetCompra.Instancia.CrearDetCompra(det);
                }
                return RedirectToAction("ListarCompra");

            }
            catch
            {
                return RedirectToAction("Error","Home");

            }
        }
    }
}