using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [Authorize]// No puede si es que no esta autorizado
    public class VentaController : Controller
    {
       
        [PermisosRol(entRol.Cliente)]
        public ActionResult ListarVenta()
        {
            entUsuario usu = Session["Usuario"] as entUsuario;
            List<entVenta> lista = logVenta.Instancia.ListarVenta(usu.IdUsuario);
            ViewBag.lista = lista;
            return View(lista);
        }

        [PermisosRol(entRol.Cliente)]
        [HttpPost]
        public ActionResult CrearVenta()
        {
            try
            {
                var detalle = logDetVenta.Instancia.Mostrardetventa();
                double total = 0;

                for (int i = 0; i < detalle.Count(); i++)
                {
                    total += detalle[i].SubTotal;
                }

                entUsuario usu = Session["Usuario"] as entUsuario;

                entUsuario cliente = new entUsuario();
                cliente.IdUsuario = usu.IdUsuario;

                entVenta venta = new entVenta();
                venta.Cliente = cliente;
                venta.Total = total;
                int idventa = logVenta.Instancia.CrearVenta(venta);
                venta.IdVenta = idventa;
                entDetVenta det = new entDetVenta();

                for (int i = 0; i < detalle.Count; i++)
                {
                    det = detalle[i];
                    det.Venta = venta;
                    logDetVenta.Instancia.CrearDetVenta(det);
                }
                detalle.Clear();
                return RedirectToAction("Listar");

            }
            catch
            {
                return RedirectToAction("Listar");

            }
        }

        public ActionResult ConfirmarVenta()
        {
            try
            {
                entUsuario usuario = new entUsuario();
                usuario = Session["Usuario"] as entUsuario;
                List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
                list = LogTemporaryProducts.Instancia.MostrarTemporaryProducts(usuario.IdUsuario);

                double total = 0;
                for (int i = 0; i < list.Count(); i++)
                {
                    total += list[i].Subtotal;
                }
                
                entVenta venta = new entVenta
                {
                    Cliente = usuario,
                    Total = total
                };

                int idVenta = logVenta.Instancia.CrearVenta(venta);
                venta.IdVenta = idVenta;

                entDetVenta det = new entDetVenta();
                for (int i = 0; i < list.Count; i++)
                {
                    det.Venta = venta;
                    det.Producto = new entProducto
                    {
                        IdProducto = list[i].ProveedorProducto.Producto.IdProducto
                    };
                    det.Cantidad = list[i].Cantidad;
                    det.SubTotal = list[i].Subtotal;

                    logDetVenta.Instancia.CrearDetVenta(det);
                }
                return RedirectToAction("ListarVenta");

            }
            catch
            {
                return RedirectToAction("Error", "Home");

            }
        }
        //[PermisosRol(entRol.Cliente)]
        //[HttpPost]
        //public ActionResult LlenarDetalle(int pCantidad, FormCollection frm)
        //{
        //    try
        //    {
        //        entDetVenta vn = new entDetVenta();
        //        entProducto prod = logProducto.Instancia.BuscarProductoId(Convert.ToInt32(frm["pProd"]));
        //        vn.Producto = prod;
        //        vn.Cantidad = pCantidad;
        //        vn.SubTotal = (pCantidad * prod.PrecioVenta);
        //        logDetVenta.Instancia.LlenarDetventa(vn);
        //        return RedirectToAction("Detalle");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Detalle");
        //    }
        //}
        //[PermisosRol(entRol.Cliente)]
        //public ActionResult Detalle()
        //{
        //    List<entDetVenta> detalle = logDetVenta.Instancia.Mostrardetventa();
        //    List<entProducto> listaproducto = logProducto.Instancia.ListarProducto();
        //    var lsproducto = new SelectList(listaproducto, "idProducto", "nombre");
        //    ViewBag.listaproducto = lsproducto;
        //    return View(detalle);
        //}
        //[PermisosRol(entRol.Cliente)]
        //public ActionResult EliminarDetalle(int ids)
        //{
        //    try
        //    {
        //        logDetVenta.Instancia.EliminarDetalle(ids);
        //        return RedirectToAction("Detalle");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Detalle");
        //    }

        //}
    }
}
