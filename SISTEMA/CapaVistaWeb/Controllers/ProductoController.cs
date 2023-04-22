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
        String mensaje = "";
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
            List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.ListarTipoProducto();
            var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            ViewBag.lista = lista;
            ViewBag.listaTipo = lsTipoProducto;
            ViewBag.Error = mensaje;
            return View(lista);
        }
        
        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult CrearProducto(string cNombreP, string cLongitudP, string cdiametro, FormCollection frm)
        {
            try
            {
                entProducto p = new entProducto
                {
                    Nombre = cNombreP,
                    Longitud = Double.Parse(cLongitudP),
                    Diametro = Double.Parse(cdiametro),
                    Tipo = new entTipoProducto()
                };

                p.Tipo.IdTipo_producto = Convert.ToInt32(frm["cTipo"]);
                bool inserta = logProducto.Instancia.CrearProducto(p);
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

            var listaTipoProducto = logTipoProducto.Instancia.ListarTipoProducto();
            var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");
            ViewBag.listaTipo = lsTipoProducto;
            return View(prod);
        }

        [PermisosRol(entRol.Administrador)]
        [HttpPost]
        public ActionResult EditarProducto(entProducto p, FormCollection frm)
        {
            p.Tipo = new entTipoProducto
            {
                IdTipo_producto = Convert.ToInt32(frm["cTipoU"])
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
                mensaje="error al eliminar";
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Ordenar(int dato)
        {
            List <entProducto> lista= logProducto.Instancia.Ordenar(dato);
            List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.ListarTipoProducto();
            var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            ViewBag.listaTipo = lsTipoProducto;
            ViewBag.lista = lista;
            return RedirectToAction("Listar");
        }

    }
}