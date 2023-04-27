using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;//Para los permisos
using MadereraCarocho.Utilidades;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;//FormsAutenticathion

namespace MadereraCarocho.Controllers
{
    public class HomeController : Controller
    {
        #region PUBLICA
        public ActionResult Index(string dato)
        {
            List<entProveedorProducto> lista;
            if (string.IsNullOrEmpty(dato))
                lista = logProducto.Instancia.ListarProductoParaVender();
            else
                lista = logProducto.Instancia.BuscarProductoParaVender(dato);

            return View(lista);
        }
        public ActionResult SinPermisos()
        {
            ViewBag.Message = "Usted no tiene permisos para acceder a esta pagina";
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarAcceso(string dato, string contra)
        {

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
        #endregion
        #region VISTA CLIENTE
        [PermisosRol(entRol.Cliente)]
        [Authorize]
        public ActionResult Cliente(string dato)
        {
            if (Session["Usuario"] != null)
            {
                List<entProveedorProducto> lista;
                if (string.IsNullOrEmpty(dato))
                    lista = logProducto.Instancia.ListarProductoParaVender();
                else
                    lista = logProducto.Instancia.BuscarProductoParaVender(dato);
                return View(lista);
            }
            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Cliente)]
        [Authorize]
        [HttpGet]
        public ActionResult EditarDatosCliente()
        {
            var usuario = Session["Usuario"] as entUsuario;
            ViewBag.listaUbigeo = new SelectList(logUbigeo.Instancia.ListarDistrito(), "idUbigeo", "distrito");
            ViewBag.Ubigeo = usuario.Ubigeo.Distrito;
            return View(usuario);

        }

        [PermisosRol(entRol.Cliente)]
        [Authorize]
        [HttpPost]
        public ActionResult EditarDatosCliente(entUsuario usu, FormCollection frm) //EDITA LOS DATOS
        {

            usu.Ubigeo = new entUbigeo
            {
                IdUbigeo = frm["Ubig"]
            };
            try
            {
                Boolean edita = logUsuario.Instancia.ActualizarAdministrador(usu);
                if (edita)
                {
                    CerrarSesion();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usu);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Cliente", new { mesjExceptio = ex.Message });
            }
        }

        [PermisosRol(entRol.Cliente)]
        [HttpGet]
        public ActionResult AgregarTempPrductCliente(int idprod)
        {
            entUsuario usuario = Session["Usuario"] as entUsuario;
            var prod = logProducto.Instancia.BuscarProductoId(idprod);
            EntTemporaryProducts temporaryProducts = new EntTemporaryProducts
            {
                ProveedorProducto = prod,
                Usuario = usuario,
                Cantidad = 1,
                Subtotal = prod.Producto.PrecioVenta
            };
            try
            {
                LogTemporaryProducts.Instancia.CreaarTemporaryProducts(temporaryProducts);
                return RedirectToAction("Cliente");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
        }
        #endregion 
        #region ADMINISTRADOR
        [PermisosRol(entRol.Administrador)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public ActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarDatosAdministrador()
        {
            var usuario = Session["Usuario"] as entUsuario;
            ViewBag.listaUbigeo = new SelectList(logUbigeo.Instancia.ListarDistrito(), "idUbigeo", "distrito");
            ViewBag.Ubigeo = usuario.Ubigeo.Distrito;
            return View(usuario);

        }
        [HttpPost]
        public ActionResult EditarDatosAdministrador(entUsuario usu, FormCollection frm) //EDITA LOS DATOS
        {

            usu.Ubigeo = new entUbigeo
            {
                IdUbigeo = frm["Ubig"]
            };
            try
            {
                Boolean edita = logUsuario.Instancia.ActualizarAdministrador(usu);
                if (edita)
                {
                    CerrarSesion();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usu);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Admin", new { mesjExceptio = ex.Message });
            }
        }
        #endregion


    }


}