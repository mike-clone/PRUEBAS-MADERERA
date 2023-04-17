using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MadereraCarocho.Utilidades;
using System.Web.Security;//FormsAutenticathion
using MadereraCarocho.Permisos;//Para los permisos

namespace MadereraCarocho.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PermisosRol(entRol.Administrador)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public ActionResult Admin()
        {
            return View();
        }

        [PermisosRol(entRol.Cliente)]
        [Authorize]// No puede si es que no esta autorizado
        public ActionResult Cliente()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public ActionResult SinPermisos()
        {
            ViewBag.Message = "Usted no tiene permisos para acceder a esta pagina";
            return View();
        }

        [HttpPost]
        public ActionResult VerificarAcceso(string dato, string contra)
        {
            //entUsuario ousuario = logUsuario.Instancia.ObtenerUsuarios().Where(u => u.Correo == dato && u.Pass == Encriptar.GetSHA256(contra)).FirstOrDefault();
            entUsuario objUsuario = logUsuario.Instancia.IniciarSesion(dato, contra);
            if (objUsuario != null)
            {
                FormsAuthentication.SetAuthCookie(objUsuario.Correo, false); //Almacenar autenticacion dentro de una cokkie (segundo parametro es que el obj no sera persistente)
                Session["Usuario"] = objUsuario;// Una sesión puede almacenar cualquier tipo de dato
                if (objUsuario.Rol == entRol.Administrador)
                {
                    return RedirectToAction("Admin"); 
                }
                else
                {
                    if (objUsuario.Rol == entRol.Cliente)
                    {
                        return RedirectToAction("Cliente");
                    }
                }
            }

            return RedirectToAction("Index"); //Si es que hay otro tipo  que te recargue la pagina
        }

        [HttpPost]
        public ActionResult SingUp(string cNombre, string cusername, string ccorreo, string cpassword)
        {
            try
            {
                entUsuario c = new entUsuario
                {
                    RazonSocial = cNombre,
                    UserName = cusername,
                    Correo = ccorreo,
                    Pass = Encriptar.GetSHA256(cpassword)
                };
                entRoll rol = new entRoll
                {
                    IdRoll = 2
                };
                c.Roll = rol;
                bool creado = logUsuario.Instancia.CrearClientes(c);
                 ViewBag.Error = "Creado";
                 return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo crear";
                return RedirectToAction("Index", new { mesjExeption = ex.Message });

            }
            
        }       
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;// Terminar la sesión
            FormsAuthentication.SignOut();// Que se cierre la autenticación
            return RedirectToAction("Index");
        }
        // Una sesion almacena toda la informacion de un objeto en el lado del servidor
    }
}