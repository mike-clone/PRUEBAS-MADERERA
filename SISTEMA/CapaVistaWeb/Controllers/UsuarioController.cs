using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(EntRol.Administrador)]// No puede acceder si es que no es administrador
    [Authorize]// No puede si es que no esta autorizado
    public class UsuarioController : Controller
    {
        readonly LogUsuario Usuarioservice;
        readonly LogUbigeo Ubigeoservice;

        public UsuarioController()
        {
            Usuarioservice = new LogUsuario(new DatUsuario());
            Ubigeoservice = new LogUbigeo(new DatUbigeo());
        }

        #region CLIENTES
        public ActionResult ListarClientes(string dato)//listar y buscar en el mismo
        {
            List<EntUsuario> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = Usuarioservice.BuscarClientes(dato);
            }
            else
            {
                lista = Usuarioservice.ListarClientes();
            }
            List<EntUbigeo> listaUbigeo = Ubigeoservice.ListarDistrito();
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
                bool elimina = Usuarioservice.EliminarUsuarios(idc);

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
            var usuario = Usuarioservice.BuscarIdUsuario(c);
            ViewBag.OldRoll = usuario.Roll.Descripcion;
            ViewBag.OldUbigeo = usuario.Ubigeo.Departamento + "  " + usuario.Ubigeo.Provincia + "  " + usuario.Ubigeo.Distrito;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarCliente(EntUsuario u)
        {
            try
            {
                Boolean edita = Usuarioservice.EditarCliente(u);
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
       
    }
}