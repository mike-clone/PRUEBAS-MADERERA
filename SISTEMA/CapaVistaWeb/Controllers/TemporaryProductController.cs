using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    
    [Authorize]// No puede si es que no esta autorizado
    public class TemporaryProductController : Controller
    {
        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult ListarTempProduct()
        {
            entUsuario usuario = new entUsuario();
            usuario = Session["Usuario"] as entUsuario;
            return View(LogTemporaryProducts.Instancia.MostrarTemporaryProducts(usuario.IdUsuario));
        }

        [PermisosRol(entRol.Cliente)]
        [HttpGet]
        public ActionResult ListarTempProductClient()
        {
            entUsuario usuario = new entUsuario();
            usuario = Session["Usuario"] as entUsuario;
            return View(LogTemporaryProducts.Instancia.MostrarTemporaryProductsCli(usuario.IdUsuario));
        }

        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult EliminarTempPrduct(int idtemp)
        {
            try
            {
                bool elimina = LogTemporaryProducts.Instancia.EliminarTemporaryProducts(idtemp);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarTempProduct");
        }

        [PermisosRol(entRol.Cliente)]
        [HttpGet]
        public ActionResult EliminarTempPrductClient(int idtemp)
        {
            try
            {
                bool elimina = LogTemporaryProducts.Instancia.EliminarTemporaryProducts(idtemp);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarTempProductClient");
        }

    }
}