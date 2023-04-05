using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(entRol.Administrador)]
    [Authorize]// No puede si es que no esta autorizado
    public class ProveedorController : Controller
    {
        public int ID= 0;
        //[HttpGet]
        public ActionResult Listar( string dato)//listar y buscar 
        {
            List<entProveedor> lista;
            if (!string.IsNullOrEmpty(dato))
            {
                 lista = logProveedor.Instancia.BuscarProveedor(dato);
            }
            else
            {
                lista = logProveedor.Instancia.ListarProveedor();

            }
            List<entUbigeo> listaUbigeo = logUbigeo.Instancia.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.lista = lista;
            ViewBag.listaUbigeo = lsUbigeo;
            return View(lista);
        }

        [HttpPost]
        public ActionResult CrearProveedor(string uNombre, string uRuc, string uCorreo, string uTelefono, string uDescripcion, FormCollection frm)
        {
            try
            {
                entProveedor p = new entProveedor();
                p.RazonSocial = uNombre;
                p.Dni = uRuc;
                p.Correo = uCorreo;
                p.Telefono = uTelefono;
                p.Descripcion = uDescripcion;
                p.EstProveedor = true;
                p.Ubigeo = new entUbigeo();
                p.Ubigeo.IdUbigeo =frm["Ubi"].ToString();
                bool inserta = logProveedor.Instancia.CrearProveedor(p);
                if (inserta)
                {
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }


        [HttpGet]
        public ActionResult EditarProveedor(int idprov)
        {
            entProveedor prov = new entProveedor();
            prov = logProveedor.Instancia.BuscarIdProveedor(idprov);

            List<entUbigeo> listaUbigeo = logUbigeo.Instancia.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;

            return View(prov);
        }
        [HttpPost]
        public ActionResult EditarProveedor(entProveedor p, FormCollection frm)
        {
            p.Ubigeo = new entUbigeo();
            p.Ubigeo.IdUbigeo =frm["Ubi"];
            try
            {
                Boolean edita = logProveedor.Instancia.ActualizarProveedor(p);
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
        public ActionResult EliminarProveedor(int idc)
        {
            try
            {
                bool elimina = logProveedor.Instancia.EliminarProveedor(idc);
                if (elimina)
                {
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }

       // [HttpGet]
        public ActionResult MostrarDetalle(int idp)
        {
            List<entProveedorProducto> lista;
            if (idp == 0)
            {
                lista = logProveedorProducto.Instancia.MostrarDetalleProvedorId(1);
                ID = 1;
            }
            else
            {
                lista = logProveedorProducto.Instancia.MostrarDetalleProvedorId(idp);
                ID = idp;
            }
            List<entProducto> listaProducto = logProducto.Instancia.ListarProducto();
            var lsProducto = new SelectList(listaProducto, "idProducto", "nombre");

            ViewBag.lista = lista;
            ViewBag.listaProducto = lsProducto;
            return View(lista);
        }

        [HttpPost]
        public ActionResult CrearDetalle(double pprecio , FormCollection frm)
        {
            try
            {
                entProducto prod = logProducto.Instancia.BuscarProductoId(Convert.ToInt32(frm["Prod"]));
                entProveedor prov = new entProveedor {
                    IdProveedor = ID
                };
                entProveedorProducto entp = new entProveedorProducto {
                    Proveedor = prov,
                    Producto = prod,
                    PrecioCompra=pprecio
                };

                bool inserta = logProveedorProducto.Instancia.CrearDetalleProvedor(entp);
                if (inserta)
                {
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }
    }
}