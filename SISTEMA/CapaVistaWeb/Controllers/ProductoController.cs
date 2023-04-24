using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MadereraCarocho.Controllers
{
    
    [Authorize]
    public class ProductoController : Controller
    {
    
        // GET: Producto
        [PermisosRol(entRol.Administrador)]
        public ActionResult Listar(string dato)//listar y buscar
        {
            List<entProducto> lista;
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
                    PrecioVenta=Double.Parse(cPrecioVenta),
                    Tipo = new entTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(frmTipo["cTipo"])
                    },
                    ProveedorProducto= new entProveedorProducto
                    {
                        Proveedor = new entProveedor
                        {
                           IdProveedor = Convert.ToInt32(frmProv["cProv"])
                        }
                    }
                   
                    
                };

                int idProducto=logProducto.Instancia.CrearProducto(p);

                entProveedorProducto pp = new entProveedorProducto
                {
                    Proveedor = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(frmProv["cProv"])
                    },
                    Producto=new entProducto
                    {
                        IdProducto= idProducto
                    },
                    PrecioCompra = Double.Parse(cprecioCompra)
                };

                _=logProveedorProducto.Instancia.CrearDetalle(pp);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }


        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult EditarProducto(int idprod)
        {
           
            var prod = logProducto.Instancia.BuscarProductoId(idprod);
            ViewBag.listaTipo = new SelectList(logTipoProducto.Instancia.SelectListTipoProductodat(prod.Tipo.IdTipo_producto), "idTipo_producto", "nombre");
            ViewBag.listaProveedor = new SelectList(logProveedor.Instancia.SelectListProveedordat(prod.ProveedorProducto.Proveedor.IdProveedor), "idProveedor", "NombreCompleto");
            return View(prod);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult EditarProducto(entProducto p, FormCollection frm,FormCollection prov)
        {
            p.Tipo = new entTipoProducto
            {
                IdTipo_producto = Convert.ToInt32(frm["tipo"])
            };
            p.ProveedorProducto = new entProveedorProducto
            {
                Proveedor=new entProveedor
                {
                    IdProveedor = Convert.ToInt32(prov["prov"])
                }
            };
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
            List <entProducto> lista= logProducto.Instancia.Ordenar(dato);
            List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.SelectListTipoProductodat(0);
            var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            ViewBag.listaTipo = lsTipoProducto;
            ViewBag.lista = lista;
            return RedirectToAction("Listar");
        }

    }
}