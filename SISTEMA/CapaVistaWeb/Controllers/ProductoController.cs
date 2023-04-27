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
        public ActionResult Listar(string dato)//listar y buscar
        {
            List<entProveedorProducto> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = logProducto.Instancia.BuscarProducto(dato);
            }
            else
            {
                lista = logProducto.Instancia.ListarProducto();
            }

            ViewBag.listaTipo = new SelectList(logTipoProducto.Instancia.SelectListTipoProductodat(0), "idTipo_producto", "nombre");
            ViewBag.listaProveedor = new SelectList(logProveedor.Instancia.SelectListProveedordat(0), "idProveedor", "NombreCompleto");
            return View(lista);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult CrearProducto(string cNombreP, string cLongitudP, string cdiametro, string cPrecioVenta, string cprecioCompra, FormCollection frmTipo, FormCollection frmProv)
        {

            try
            {
                entProducto p = new entProducto
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
                int idProducto = logProducto.Instancia.CrearProducto(p);

                entProveedorProducto pp = new entProveedorProducto
                {
                    Proveedor = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(frmProv["cProv"])
                    },
                    Producto = new entProducto
                    {
                        IdProducto = idProducto
                    },
                    PrecioCompra = Double.Parse(cprecioCompra)
                };

                _ = logProveedorProducto.Instancia.CrearDetalle(pp);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }


        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult EditarProductos(int idprod)
        {
            List<entProveedor> lsprov;
            List<entTipoProducto> lstipo;
            var prod = logProducto.Instancia.BuscarProductoId(idprod);
            if(prod.Producto.Tipo==null)
            lstipo = logTipoProducto.Instancia.SelectListTipoProductodat(0);
            else
            lstipo = logTipoProducto.Instancia.SelectListTipoProductodat(prod.Producto.Tipo.IdTipo_producto);
            if (prod.Proveedor==null)
                lsprov = logProveedor.Instancia.SelectListProveedordat(0);
            else
                lsprov = logProveedor.Instancia.SelectListProveedordat(prod.Proveedor.IdProveedor);
            ViewBag.listaTipos = new SelectList(lstipo, "idTipo_producto", "nombre");
            ViewBag.listaProveedores = new SelectList(lsprov, "idProveedor", "NombreCompleto");
            return View(prod);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult EditarProductos(entProveedorProducto p, FormCollection frm, FormCollection prov)
        {
            entProducto product = new entProducto
            {
                IdProducto = p.Producto.IdProducto,
                Nombre = p.Producto.Nombre,
                Longitud = p.Producto.Longitud,
                Diametro = p.Producto.Diametro,
                Activo = p.Producto.Activo,
                Tipo = new entTipoProducto
                {
                    IdTipo_producto = Convert.ToInt32(frm["Stip"])
                }
            };
            p.Proveedor = new entProveedor
            {
                IdProveedor = Convert.ToInt32(prov["Prv"])
            };
            p.Producto = product;

            try
            {
              
                Boolean edita = logProducto.Instancia.ActualizarProducto(p);
                if (edita)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Listar", new { mesjExceptio = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult EliminarProducto(int idP)
        {
            try
            {
                bool elimina = logProducto.Instancia.EliminarProducto(idP);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Ordenar(int dato)
        {
            List<entProveedorProducto> lista = logProducto.Instancia.Ordenar(dato);
            List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.SelectListTipoProductodat(0);
            var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            ViewBag.listaTipo = lsTipoProducto;
            ViewBag.lista = lista;
            return RedirectToAction("Listar");
        }
        
        [HttpGet]
        public ActionResult AgregarTempPrduct(int idprod)
        {
            entUsuario usuario = Session["Usuario"] as entUsuario;
            var proprod = logProducto.Instancia.BuscarProductoId(idprod);
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
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
        }

    }
}