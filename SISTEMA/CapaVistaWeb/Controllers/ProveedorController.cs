using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(entRol.Administrador)]
    [Authorize]// No puede si es que no esta autorizado
    public class ProveedorController : Controller
    {

        public ActionResult Listar(string dato)//listar y buscar 
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
            ViewBag.listaUbigeo = lsUbigeo;
            return View(lista);
        }

        [HttpPost]
        public ActionResult CrearProveedor(string uNombre, string uRuc, string uCorreo, string uTelefono, string uDescripcion, FormCollection frm)
        {
            try
            {
                entProveedor p = new entProveedor
                {
                    RazonSocial = uNombre,
                    Ruc = uRuc,
                    Correo = uCorreo,
                    Telefono = uTelefono,
                    Descripcion = uDescripcion,
                    EstProveedor = true,
                    Ubigeo = new entUbigeo
                    {
                        IdUbigeo = frm["Ubi"].ToString()
                    }
                };


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
            entProveedor prov = logProveedor.Instancia.BuscarIdProveedor(idprov);

            List<entUbigeo> listaUbigeo = logUbigeo.Instancia.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;

            return View(prov);
        }

        [HttpPost]
        public ActionResult EditarProveedor(entProveedor p, FormCollection frm)
        {
            p.Ubigeo = new entUbigeo
            {
                IdUbigeo = frm["Ubi"]
            };
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

        [HttpGet]
        public ActionResult MostrarDetalle(int idp)
        {
            try
            {
                return View(_ = logProveedorProducto.Instancia.MostrarDetalleProvedorId(idp));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult EliminarDetalle(int idprov, int idprod)
        {
            try
            {
                bool elimina = logProveedorProducto.Instancia.EliminarDetalle(idprov, idprod);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }

            return RedirectToAction("Listar");
        }
    }
}