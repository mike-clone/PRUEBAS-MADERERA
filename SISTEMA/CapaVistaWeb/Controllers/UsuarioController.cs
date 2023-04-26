using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(entRol.Administrador)]// No puede acceder si es que no es administrador
    [Authorize]// No puede si es que no esta autorizado
    public class UsuarioController : Controller
    {


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
            ViewBag.Error = "listando";
            return View(lista);
        }

        [HttpGet]
        public ActionResult EliminarClientes(int idc)
        {
            try
            {
                bool elimina = logUsuario.Instancia.EliminarUsuarios(idc);

                ViewBag.Error = "Cliente eliminado correctamente";

            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo eliminar";
                return RedirectToAction("ListarClientes", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarClientes");
        }

        [HttpGet]
        public ActionResult EditarCliente(int c)
        {
            var usuario = logUsuario.Instancia.BuscarIdUsuario(c);
            ViewBag.OldRoll = usuario.Roll.Descripcion;
            ViewBag.OldUbigeo = usuario.Ubigeo.Departamento + "  " + usuario.Ubigeo.Provincia + "  " + usuario.Ubigeo.Distrito;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarCliente(entUsuario u)
        {
            try
            {
                Boolean edita = logUsuario.Instancia.EditarCliente(u);
                if (edita)
                {
                    return RedirectToAction("ListarClientes");
                }
                else
                {
                    return View(u);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListarClientes", new { mesjExceptio = ex.Message });
            }
        }
        #endregion

        #region ADMINISTRADORES
        #endregion

        #region EMPLEADOS
        #endregion

        #region REGION COMPARTIDA

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






    }
}