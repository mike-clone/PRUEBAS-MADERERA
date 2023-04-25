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
        public ActionResult Index()
        {
            //entUsuario user = Session["Usuario"] as entUsuario;
            List<entCompra> detCompra = logCompra.Instancia.ListarCompra();
            return View(detCompra);
        }
        public ActionResult ListarTempProduct()
        {
            var usuario = Session["Usuario"] as entUsuario;
            return View(LogTemporaryProducts.Instancia.MostrarTemporaryProducts(usuario.IdUsuario));
        }
        //[HttpPost]
        //public ActionResult AgregarDetCarrito(int pvCantidad, FormCollection frm)
        //{

        //    try
        //    {
        //        entDetCompra detCompra = new entDetCompra();
        //        entProducto prod = logProducto.Instancia.BuscarProductoId(Convert.ToInt32(frm["Prd"]));
        //        detCompra.Producto = prod;
        //        detCompra.Cantidad = pvCantidad;
        //        detCompra.Subtotal = (pvCantidad * prod.ProveedorProducto.PrecioCompra);
        //        logDetCompra.Instancia.AgregarProductoCarrito(detCompra);
        //        return RedirectToAction("DetalleCarrito");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("DetalleCarrito");
        //    }
        //}
        //public ActionResult EliminarDetalle(int ids)
        //{
        //    try
        //    {
        //        logDetCompra.Instancia.EliminarDetCarrito(ids);
        //        return RedirectToAction("DetalleCarrito");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("DetalleCarrito");
        //    }

        //}

        //[HttpPost]
        //public ActionResult ConfirmarCompra(FormCollection frm)
        //{
        //    try
        //    {
        //        //Obtenemos la lista del detalle
        //        var detalle = logDetCompra.Instancia.MostrarDetCarrito();

        //        //Calculamos el total de toda la compra
        //        double total = 0;
        //        for (int i = 0; i < detalle.Count(); i++)
        //        {
        //            total += detalle[i].Subtotal;
        //        }

        //        entProveedor proveedor = logProveedor.Instancia.BuscarIdProveedor(Convert.ToInt32(frm["Prov"]));

        //        entCompra compra = new entCompra
        //        {
        //            Proveedor = proveedor,
        //            Total = total
        //        };
        //        //Obtenemos el id de la compra creada
        //        int idCompra = logCompra.Instancia.CrearCompra(compra);
        //        compra.IdCompra = idCompra;

        //        entDetCompra det = new entDetCompra();
        //        for (int i = 0; i < detalle.Count; i++)
        //        {
        //            det = detalle[i];
        //            det.Compra = compra;
        //            logDetCompra.Instancia.CrearDetCompra(det);
        //        }
        //        detalle.Clear();
        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index");

        //    }
        //}
    }
}