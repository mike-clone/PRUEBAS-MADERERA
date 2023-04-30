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
            entUsuario usuario = new entUsuario();
            usuario = Session["Usuario"] as entUsuario;
            return View(logVenta.Instancia.ListarVenta(usuario.IdUsuario));
        }

        public ActionResult MostrarDetalle(int idv)
        {
            //try
            //{
            //    ViewBag.producto = new SelectList(logProducto.Instancia.ListarProducto(), "idProducto", "NombreCompleto");
            //    return View(_ = logProveedorProducto.Instancia.MostrarDetalleProvedorId(idp));
            //}
            //catch (Exception ex)
            //{
            //    return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            //}
            return View(_ = logDetVenta.Instancia.Mostrardetventa(idv));
        }


        public ActionResult ConfirmarVenta()
        {
            try
            {
                entUsuario usuario = new entUsuario();
                usuario = Session["Usuario"] as entUsuario;
                List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
                list = LogTemporaryProducts.Instancia.MostrarTemporaryProductsCli(usuario.IdUsuario);

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
