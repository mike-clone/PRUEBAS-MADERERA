using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(EntRol.Administrador)]
    [Authorize]// No puede si es que no esta autorizado
    public class ProveedorController : Controller
    {
        readonly LogProducto Productoservice;
        readonly LogProveedorProducto ProveedorProductoservice;
        readonly LogUbigeo Ubigeoservice;
        readonly LogProveedor Proveedorservice;
        readonly ValidatorHelper validatorHelper = new ValidatorHelper();

        public ProveedorController()
        {
            Productoservice = new LogProducto(new DatProducto());
            ProveedorProductoservice = new LogProveedorProducto(new DatProveedorProducto());
            Ubigeoservice = new LogUbigeo(new DatUbigeo());
            Proveedorservice = new LogProveedor(new DatProveedor());
        }
        public ActionResult Listar(string dato)//listar y buscar 
        {
            List<EntProveedor> lista;
            if (!string.IsNullOrEmpty(dato))
            {
                lista = Proveedorservice.BuscarProveedor(dato);
            }
            else
            {
                lista = Proveedorservice.ListarProveedor();

            }
            List<EntUbigeo> listaUbigeo = Ubigeoservice.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;
            return View(lista);
        }
        [HttpGet]
        public ActionResult RegistrarProveedor()
        {
            List<EntUbigeo> listaUbigeo = Ubigeoservice.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProveedor(string nombre , string ruc, string email, string telefono, string description, FormCollection frm)
        {
            bool isNonEmpty=!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(ruc) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(telefono) || !string.IsNullOrEmpty(description);
            try
            {
                if (isNonEmpty)
                {
                    EntProveedor p = new EntProveedor
                    {
                        RazonSocial = nombre,
                        Ruc = ruc,
                        Correo = email,
                        Telefono = telefono,
                        Descripcion = description,
                        EstProveedor = true,
                        Ubigeo = new EntUbigeo
                        {
                            IdUbigeo = frm["ubigeo"].ToString()
                        }
                    };

                    bool inserta = Proveedorservice.CrearProveedor(p);
                }
                
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("../Home/Error");
            }
            return RedirectToAction("Listar");
        }


        [HttpGet]
        public ActionResult EditarProveedor(int idprov)
        {
            EntProveedor prov = Proveedorservice.BuscarIdProveedor(idprov);

            List<EntUbigeo> listaUbigeo = Ubigeoservice.ListarDistrito();
            var lsUbigeo = new SelectList(listaUbigeo, "idUbigeo", "distrito");
            ViewBag.listaUbigeo = lsUbigeo;

            return View(prov);
        }

        [HttpPost]
        public ActionResult EditarProveedor(EntProveedor p, FormCollection frm)
        {
            bool isNonEmpty = !string.IsNullOrEmpty(p.RazonSocial) || !string.IsNullOrEmpty(p.Ruc) || !string.IsNullOrEmpty(p.Correo) || !string.IsNullOrEmpty(p.Telefono) || !string.IsNullOrEmpty(p.Descripcion);

            try
            {
                if (isNonEmpty)
                {
                    p.Ubigeo = new EntUbigeo
                    {
                        IdUbigeo = frm["Ubi"]
                    };
                     Proveedorservice.ActualizarProveedor(p);
                }else
                {
                    TempData["errorEdit"] = "Todos los datos son obligatorios";

                    return View(p);
                }
               
            }
            catch (Exception ex)
            {
               TempData["error"] = ex.Message;
               return View(p);
            }
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult EliminarProveedor(int idc)
        {
            try
            {
                bool elimina = Proveedorservice.EliminarProveedor(idc);
                if (elimina)
                {
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult MostrarDetalle(int idp)
        {
            try
            {
                ViewBag.producto = new SelectList(Productoservice.ListarProducto(),"IdProducto", "NombreCompleto");
                return View(_ = ProveedorProductoservice.MostrarDetalleProvedorId(idp));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult ElegirProductos(int proveedor, double precio, FormCollection frm)
        {
            EntProveedorProducto PP = new EntProveedorProducto
            {
                Proveedor = new EntProveedor
                {
                    IdProveedor = proveedor,
                },
                Producto = new EntProducto
                {
                    IdProducto = Convert.ToInt32(frm["Pr"])
                },
                PrecioCompra= (double)precio
                
            };
            ProveedorProductoservice.CrearProveedorProducto(PP);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult EliminarDetalle(int idprov, int idprod)
        {
            try
            {
                bool elimina = ProveedorProductoservice.EliminarDetalleProveedor(idprov, idprod);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Listar", new { mesjExeption = ex.Message });
            }

            return RedirectToAction("Listar");
        }
    }
}