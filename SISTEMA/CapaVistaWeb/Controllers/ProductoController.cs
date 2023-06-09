﻿using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{

    [Authorize]
    public class ProductoController : Controller
    {
        readonly LogProducto Productoservice;
        readonly LogProveedorProducto ProveedorProductoservice;
        readonly LogTemporaryProducts TemporaryPservice;
        readonly LogTipoProducto TipoProductoservice;

        public ProductoController()
        {
            Productoservice = new LogProducto(new DatProducto());
            TemporaryPservice = new LogTemporaryProducts(new DatTemporaryProducts());
            ProveedorProductoservice = new LogProveedorProducto(new DatProveedorProducto());
            TipoProductoservice = new LogTipoProducto(new DatTipoProducto());
        }
        // GET: Producto
        [PermisosRol(EntRol.Administrador)]
        public ActionResult ListarParaComprar(string dato)//listar y buscar
        {
            List<EntProveedorProducto> lista;
            if (!String.IsNullOrEmpty(dato))
            {
                lista = ProveedorProductoservice.BuscarProductoParaComprar(dato);
            }
            else
            {
                lista = ProveedorProductoservice.ListarProductoParaComprar();
            }

            
            return View(lista);
        }

        [PermisosRol(EntRol.Administrador)]
        public ActionResult ListarProducto( string dato)
        {
            List<EntProducto> lista;
            if(!string.IsNullOrEmpty(dato))
                lista= Productoservice.BuscarProducto(dato);
            else
               lista= Productoservice.ListarProducto();

            ViewBag.listaTipo = new SelectList(TipoProductoservice.SelectListTipoProductodat(0), "idTipo_producto", "nombre");
            return View(lista);
        }

        [PermisosRol(EntRol.Administrador)]
        [HttpPost]
        public ActionResult CrearProducto(string cNombreP, string cLongitudP, string cdiametro, string cPrecioVenta, string cprecioCompra, FormCollection frmTipo)
        {

            try
            {
                EntProducto p = new EntProducto
                {
                    Nombre = cNombreP,
                    Longitud = Double.Parse(cLongitudP),
                    Diametro = Double.Parse(cdiametro),
                    PrecioVenta = Double.Parse(cPrecioVenta),
                    Tipo = new EntTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(frmTipo["cTipo"])
                    },
                };
                Productoservice.CrearProducto(p);

            }
            catch (Exception ex)
            {
                return RedirectToAction("ListarProducto", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarProducto");
        }


        [PermisosRol(EntRol.Administrador)]
        [HttpGet]
        public ActionResult EditarProducto(int idprod)
        {
            var prod = Productoservice.BuscarProductoId(idprod);
            ViewBag.listaTipos = new SelectList(TipoProductoservice.SelectListTipoProductodat(prod.IdProducto), "idTipo_producto", "nombre");
            return View(prod);
        }

        [PermisosRol(EntRol.Administrador)]
        [HttpPost]
        public ActionResult EditarProducto(EntProducto p, FormCollection frm)
        {

            p.IdProducto = p.IdProducto;
            p.Nombre = p.Nombre;
            p.Longitud = p.Longitud;
            p.Diametro = p.Diametro;
            p.Activo = p.Activo;
            p.Tipo = new EntTipoProducto
              {
                IdTipo_producto = Convert.ToInt32(frm["Stip"])
              };

            try
            {
              
                Boolean edita = Productoservice.ActualizarProducto(p);
                if (edita)
                {
                    return RedirectToAction("ListarProducto");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListarProducto", new { mesjExceptio = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult EliminarProducto(int idP)
        {
            try
            {
                bool elimina = Productoservice.EliminarProducto(idP);
            }
            catch (Exception ex)
            {

                return RedirectToAction("ListarProducto", new { mesjExeption = ex.Message });
            }
            return RedirectToAction("ListarProducto");
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
                return RedirectToAction("ListarParaComprar", new { mesjExeption = ex.Message });
            }

            return RedirectToAction("ListarParaComprar");
        }

        [HttpGet]
        public ActionResult AgregarTempPrduct(int idprod, int idprov)
        {
            EntUsuario usuario = Session["Usuario"] as EntUsuario;
            var proprod = ProveedorProductoservice.BuscarProvedorProductoId(idprod, idprov);
            EntTemporaryProducts temporaryProducts = new EntTemporaryProducts
            {
                ProveedorProducto = proprod,
                Usuario = usuario,
                Cantidad = 1,
                Subtotal = proprod.PrecioCompra
            };
            try
            {
                TemporaryPservice.CreaarTemporaryProducts(temporaryProducts);
                return RedirectToAction("ListarParaComprar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { mesjExeption = ex.Message });
            }
            //[HttpGet]
            //public ActionResult Ordenar(int dato)
            //{
            //    List<entProveedorProducto> lista = logProducto.Instancia.Ordenar(dato);
            //    List<entTipoProducto> listaTipoProducto = logTipoProducto.Instancia.SelectListTipoProductodat(0);
            //    var lsTipoProducto = new SelectList(listaTipoProducto, "idTipo_producto", "nombre");

            //    ViewBag.listaTipo = lsTipoProducto;
            //    ViewBag.lista = lista;
            //    return RedirectToAction("Listar");
            //}
        }

    }
}