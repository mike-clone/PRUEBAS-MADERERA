using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using MadereraCarocho.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(entRol.Administrador)]// No puede acceder si es que no es administrador
    [Authorize]// No puede si es que no esta autorizado
    public class UsuarioController : Controller
    {
        private string mensaje;

        #region CLIENTES
        public ActionResult ListarClientes(string dato)//listar y buscar en el mismo
        {
            List<entUsuario> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = logUsuario.Instancia.BuscarClientes(dato); 
            }
            else
            {
                lista = logUsuario.Instancia.ListarClientes();
            }
            List<entUbigeo> listaUbigeo = logUbigeo.Instancia.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");

            ViewBag.lista = lista;
            ViewBag.listaUbigeo = lsUbigeo;
            ViewBag.Mensaje = mensaje;
            return View(lista);
        }

        #endregion

        #region ADMINISTRADORES
        public ActionResult ListarAdministradores(string dato)
        {
            List<entUsuario> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = logUsuario.Instancia.BuscarAdministradores(dato);
            }
            else
            {
                lista = logUsuario.Instancia.ListarAdministradores();
            }
            List<entRoll> listaRol = logRoll.Instancia.ListarRol();
            var lsRol = new SelectList(listaRol, "idRol", "descripcion");

            List<entUbigeo> listaUbigeo = logUbigeo.Instancia.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");

            ViewBag.lista = lista;
            ViewBag.listaUbigeo = lsUbigeo;
            ViewBag.listaRoll = lsRol;
            return View(lista);
        }
        #endregion

        //[HttpGet]


        /*[HttpGet]
        public ActionResult EliminarUsuarioAdmin(int idu)
        {
            try
            {
                bool elimina = logUsuario.Instancia.EliminarUsuaro(idu);
                if (elimina)
                {
                    return RedirectToAction("ListarAdmin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("ListarAdmin", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarAdmin");
        }*/
        [HttpGet]
        public ActionResult EditarCliente(int c)
        {
            List<entRoll> listaRoll = logRoll.Instancia.ListarRol();
            var lsroll = new SelectList(listaRoll, "idRoll", "descripcion");
            ViewBag.listaRoll = lsroll;
            return View(_ = logUsuario.Instancia.BuscarIdCliente(c));
        }

        [HttpGet]
        public ActionResult EliminarCliente(int idP)
        {
            try
            {
                bool elimina = logUsuario.Instancia.EliminarCliente(idP);
                if (elimina)
                {
                    mensaje = "Cliente eliminado correctamente";
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