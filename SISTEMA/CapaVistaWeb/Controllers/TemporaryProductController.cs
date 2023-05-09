using CapaAccesoDatos;
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
        LogTemporaryProducts TemporaryPservice;

        public TemporaryProductController()
        {
            TemporaryPservice = new LogTemporaryProducts(new DatTemporaryProducts());
        }


        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult ListarTempProduct()
        {
            EntUsuario usuario = new EntUsuario();
            usuario = Session["Usuario"] as EntUsuario;
            return View(TemporaryPservice.MostrarTemporaryProducts(usuario.IdUsuario));
        }

        [PermisosRol(entRol.Cliente)]
        [HttpGet]
        public ActionResult ListarTempProductClient()
        {
            EntUsuario usuario = new EntUsuario();
            usuario = Session["Usuario"] as EntUsuario;
            return View(TemporaryPservice.MostrarTemporaryProductsCli(usuario.IdUsuario));
        }

        [PermisosRol(entRol.Administrador)]
        [HttpGet]
        public ActionResult EliminarTempPrduct(int idtemp)
        {
            try
            {
                bool elimina = TemporaryPservice.EliminarTemporaryProducts(idtemp);
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
                bool elimina = TemporaryPservice.EliminarTemporaryProducts(idtemp);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarTempProductClient");
        }

    }
}