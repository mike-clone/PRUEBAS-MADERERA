using CapaEntidad;
using System.Web;
using System.Web.Mvc;//Para ActionFilterAttribute

namespace MadereraCarocho.Permisos
{
    // Resumen:
    //      Valida que al momento que se ejecute una accion valida cierta acción.
    public class PermisosRolAttribute : ActionFilterAttribute //Le decimos que va a heredar de action filter
    {
        private readonly entRol Rol;

        public PermisosRolAttribute(entRol Rol)
        {
            this.Rol = Rol;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Primero validamos que exista una sesión
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                // Convertimos la sesion que contiene la info del usuario se convierta al tipo usuario
                var usuario = HttpContext.Current.Session["Usuario"] as EntUsuario;
                if (usuario.Rol != Rol)
                {
                    filterContext.Result = new RedirectResult("~/Home/SinPermisos");
                    //Con ~ le decimos que se rediriga a la ubicación del proyecto
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}