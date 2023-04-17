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

                ViewBag.Error="Cliente eliminado correctamente";
  
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
            var usuario =logUsuario.Instancia.BuscarIdUsuario(c);
            List<entRoll> listaRoll = logRoll.Instancia.ListarRol();
            var lsroll = new SelectList(listaRoll, "idRoll", "descripcion");
            ViewBag.listaRoll = lsroll;
            ViewBag.OldUbigeo=usuario.Ubigeo.Departamento+"  "+usuario.Ubigeo.Provincia+"  "+usuario.Ubigeo.Distrito;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarCliente(entUsuario u ,FormCollection frm)
        {
            u.Roll = new entRoll()
            {
                IdRoll = Convert.ToInt32(frm["roll"])
            };

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

        [HttpGet]
        public ActionResult EliminarAdministradores(int idA)
        {
            try
            {
                bool elimina = logUsuario.Instancia.EliminarUsuarios(idA);

                ViewBag.Error = "adminsitrador eliminado correctamente";

            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo eliminar";
                return RedirectToAction("ListarAdministradores", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarAdministradores");
        }
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