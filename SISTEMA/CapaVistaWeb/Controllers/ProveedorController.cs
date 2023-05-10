using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [PermisosRol(entRol.Administrador)]
    [Authorize]// No puede si es que no esta autorizado
    public class ProveedorController : Controller
    {
        LogProducto Productoservice;
        LogProveedorProducto ProveedorProductoservice;
        LogUbigeo Ubigeoservice;
        LogProveedor Proveedorservice;

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

        [HttpPost]
        public ActionResult CrearProveedor(string uNombre, string uRuc, string uCorreo, string uTelefono, string uDescripcion, FormCollection frm)
        {
            try
            {
                EntProveedor p = new EntProveedor
                {
                    RazonSocial = uNombre,
                    Ruc = uRuc,
                    Correo = uCorreo,
                    Telefono = uTelefono,
                    Descripcion = uDescripcion,
                    EstProveedor = true,
                    Ubigeo = new EntUbigeo
                    {
                        IdUbigeo = frm["Ubi"].ToString()
                    }
                };


                bool inserta = Proveedorservice.CrearProveedor(p);
                if (inserta)
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
            p.Ubigeo = new EntUbigeo
            {
                IdUbigeo = frm["Ubi"]
            };
            try
            {
                Boolean edita = Proveedorservice.ActualizarProveedor(p);
                if (edita)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Listar", new { mesjExceptio = ex.Message });
            }
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
                ViewBag.producto = new SelectList(Productoservice.ListarProducto(),"idProducto", "NombreCompleto");
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
                PrecioCompra=precio
                
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