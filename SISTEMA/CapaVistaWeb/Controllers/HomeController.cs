using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;//Para los permisos
using MadereraCarocho.Utilidades;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Security;//FormsAutenticathion

namespace MadereraCarocho.Controllers
{
    
    public class HomeController : Controller
    {
        LogUsuario Usuarioservice;
        LogProducto Productoservice;
        LogUbigeo Ubigeoservice;
        LogTemporaryProducts TemporaryPservice;

        public HomeController()
        {
            Usuarioservice = new LogUsuario(new DatUsuario());
            Productoservice = new LogProducto(new DatProducto());
            Ubigeoservice = new LogUbigeo(new DatUbigeo());
            TemporaryPservice = new LogTemporaryProducts(new DatTemporaryProducts());
        }
        #region PUBLICA
        public ActionResult Index(string dato)
        {
            List<EntProducto> lista;
            if (string.IsNullOrEmpty(dato))
                lista = Productoservice.ListarProducto();
            else
                lista = Productoservice.BuscarProducto(dato);

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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registro()
        {
            List<EntUbigeo> listaUbigeo = Ubigeoservice.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;
            return View();
        }
        [HttpPost]
        public ActionResult VerificarAcceso(string user, string pass)
        {
            
            try
            {
                if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)))
                {
                    EntUsuario objUsuario = Usuarioservice.IniciarSesion(user, pass);
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
                }
                
          
               
            }
            catch(Exception ex)
            {
                TempData["error"]= ex.Message;
                TempData["Mensaje"] = "user or password invalid";
                return RedirectToAction("Login");

            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult SingUp(string nombre, string username, string email, string password,FormCollection ubi)
        {
            
            try
            {
               if(!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(username)  && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password)) 
               {
                    EntUsuario c = new EntUsuario
                    {
                        RazonSocial = nombre,
                        UserName = username,
                        Correo = email,
                        Pass = Encriptar.GetSHA256(password),
                        Roll = new entRoll
                        {
                            IdRoll = 2
                        },
                        Ubigeo = new EntUbigeo
                        {
                            IdUbigeo = ubi["ubigeo"].ToString()
                        }
                    };
                    bool creado = Usuarioservice.CrearClientes(c);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] =ex.Message ;
                return RedirectToAction("Error");
            }
            return RedirectToAction("Login");
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
                List<EntProducto> lista;
                if (string.IsNullOrEmpty(dato))
                    lista = Productoservice.ListarProducto();
                else
                    lista = Productoservice.BuscarProducto(dato);
                return View(lista);
            }
            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Cliente)]
        [Authorize]
        [HttpGet]
        public ActionResult EditarDatosCliente()
        {
            var usuario = Session["Usuario"] as EntUsuario;
            ViewBag.listaUbigeo = new SelectList(Ubigeoservice.ListarDistrito(), "idUbigeo", "distrito");
            ViewBag.Ubigeo = usuario.Ubigeo.Distrito;
            return View(usuario);

        }

        [PermisosRol(entRol.Cliente)]
        [Authorize]
        [HttpPost]
        public ActionResult EditarDatosCliente(EntUsuario usu, FormCollection frm) //EDITA LOS DATOS
        {

            usu.Ubigeo = new EntUbigeo
            {
                IdUbigeo = frm["Ubig"]
            };
            try
            {
                Boolean edita = Usuarioservice.ActualizarAdministrador(usu);
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
            EntUsuario usuario = Session["Usuario"] as EntUsuario;
            var prod = Productoservice.BuscarProductoId(idprod);
            EntTemporaryProducts temporaryProducts = new EntTemporaryProducts
            {
                ProveedorProducto = new EntProveedorProducto
                {
                    Producto = prod,
                },
                Usuario = usuario,
                Cantidad = 1,
                Subtotal = prod.PrecioVenta
            };
            try
            {
                TemporaryPservice.CreaarTemporaryProductsCli(temporaryProducts);
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
            EntUsuario usuario = new EntUsuario();
            usuario=Session["Usuario"] as EntUsuario;
            ViewBag.correo =usuario.Correo;
            return View();
        }

        [PermisosRol(entRol.Administrador)]
        [Authorize]
        [HttpGet]
        public ActionResult EditarDatosAdministrador()
        {
            var usuario = Session["Usuario"] as EntUsuario;
            ViewBag.listaUbigeo = new SelectList(Ubigeoservice.ListarDistrito(), "idUbigeo", "distrito");
            ViewBag.Ubigeo = usuario.Ubigeo.Distrito;
            return View(usuario);

        }
        [HttpPost]

        [PermisosRol(entRol.Administrador)]
        [Authorize]
        public ActionResult EditarDatosAdministrador(EntUsuario usu, FormCollection frm) //EDITA LOS DATOS
        {

            usu.Ubigeo = new EntUbigeo
            {
                IdUbigeo = frm["Ubig"]
            };
            try
            {
                Boolean edita = Usuarioservice.ActualizarAdministrador(usu);
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