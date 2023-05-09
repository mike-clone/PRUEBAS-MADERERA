using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{

    [Authorize]
    public class ProductoController : Controller
    {

        // GET: Producto
        [PermisosRol(entRol.Administrador)]
        public ActionResult ListarParaComprar(string dato)//listar y buscar
        {
            List<entProveedorProducto> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = logProveedorProducto.Instancia.BuscarProductoParaComprar(dato);
            }
            else
            {
                lista = logProveedorProducto.Instancia.ListarProductoParaComprar();
            }

            
            return View(lista);
        }

        [PermisosRol(entRol.Administrador)]
        public ActionResult ListarProducto( string dato)
        {
            List<EntProducto> lista;
            if(!string.IsNullOrEmpty(dato))
                lista=LogProducto.Instancia.BuscarProducto(dato);
            else
               lista=LogProducto.Instancia.ListarProducto();

            ViewBag.listaTipo = new SelectList(logTipoProducto.Instancia.SelectListTipoProductodat(0), "idTipo_producto", "nombre");
            return View(lista);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult CrearProducto(string cNombreP, string cLongitudP, string cdiametro, string cPrecioVenta, string cprecioCompra, FormCollection frmTipo)
        {

            try
            {
                EntProducto p = new EntProducto
                {
                    Nombre = cNombreP,
                    Longitud = Double.Parse(cLongitudP),
                    Diametro = Double.Parse(cdiametro),
                    PrecioVenta = Double.Parse(cPrecioVenta),
                    Tipo = new entTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(frmTipo["cTipo"])
                    },
                };
                LogProducto.Instancia.CrearProducto(p);

            }
            catch (Exception ex)
            {
                return RedirectToAction("ListarProducto", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarProducto");
        }


        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult EditarProducto(int idprod)
        {
            var prod = LogProducto.Instancia.BuscarProductoId(idprod);
            ViewBag.listaTipos = new SelectList(logTipoProducto.Instancia.SelectListTipoProductodat(prod.IdProducto), "idTipo_producto", "nombre");
            return View(prod);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult EditarProducto(EntProducto p, FormCollection frm)
        {

            p.IdProducto = p.IdProducto;
            p.Nombre = p.Nombre;
            p.Longitud = p.Longitud;
            p.Diametro = p.Diametro;
            p.Activo = p.Activo;
            p.Tipo = new entTipoProducto
              {
                IdTipo_producto = Convert.ToInt32(frm["Stip"])
              };

            try
            {
              
                Boolean edita = LogProducto.Instancia.ActualizarProducto(p);
                if (edita)
                {
                    return RedirectToAction("ListarProducto");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListarProducto", new { mesjExceptio = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult EliminarProducto(int idP)
        {
            try
            {
                bool elimina = LogProducto.Instancia.EliminarProducto(idP);
            }
            catch (Exception ex)
            {

                return RedirectToAction("ListarProducto", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarProducto");
        }

        [HttpGet]
        public ActionResult EliminarDetalle(int idprov, int idprod)
        {
            try
            {
                bool elimina = logProveedorProducto.Instancia.EliminarDetalleProveedor(idprov, idprod);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ListarParaComprar", new { mesjExeption = ex.Message });
            }

            return RedirectToAction("ListarParaComprar");
        }

        [HttpGet]
        public ActionResult AgregarTempPrduct(int idprod, int idprov)
        {
            EntUsuario usuario = Session["Usuario"] as EntUsuario;
            var proprod = logProveedorProducto.Instancia.BuscarProvedorProductoId(idprod, idprov);
            EntTemporaryProducts temporaryProducts = new EntTemporaryProducts
            {
                ProveedorProducto = proprod,
                Usuario = usuario,
                Cantidad = 1,
                Subtotal = proprod.PrecioCompra
            };
            try
            {
                LogTemporaryProducts.Instancia.CreaarTemporaryProducts(temporaryProducts);
                return RedirectToAction("ListarParaComprar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
            //[HttpGet]
            //public ActionResult Ordenar(int dato)
            //{
            //    List<entProveedorProducto> lista = logProducto.Instancia.Ordenar(dato);
            //    List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.SelectListTipoProductodat(0);
            //    var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            //    ViewBag.listaTipo = lsTipoProducto;
            //    ViewBag.lista = lista;
            //    return RedirectToAction("Listar");
            //}
        }

    }
}