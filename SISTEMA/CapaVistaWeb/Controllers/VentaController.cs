using CapaAccesoDatos;
using CapaEntidad;
using CapaLogica;
using MadereraCarocho.Permisos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MadereraCarocho.Controllers
{
    [Authorize]// No puede si es que no esta autorizado
    public class VentaController : Controller
    {

        readonly LogVenta Ventaservice;
        readonly LogDetVenta DetVentaservice;
        readonly LogTemporaryProducts TemporaryPservice;

        public VentaController()
        {
            Ventaservice = new LogVenta(new DatVenta());
            DetVentaservice = new LogDetVenta(new DatDetVenta());
            TemporaryPservice = new LogTemporaryProducts(new DatTemporaryProducts());
        }

        [PermisosRol(EntRol.Cliente)]
        public ActionResult ListarVenta()
        {
            EntUsuario usuario = new EntUsuario();
            usuario = Session["Usuario"] as EntUsuario;
            return View(Ventaservice.ListarVenta(usuario.IdUsuario));
        }

        [PermisosRol(EntRol.Cliente)]
        public ActionResult MostrarDetalle(int idv)
        {
            return View(_ = DetVentaservice.Mostrardetventa(idv));
        }
    

        [PermisosRol(EntRol.Cliente)]
        public ActionResult ConfirmarVenta()
        {
            try
            {
                EntUsuario usuario = new EntUsuario();
                usuario = Session["Usuario"] as EntUsuario;
                List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
                list = TemporaryPservice.MostrarTemporaryProductsCli(usuario.IdUsuario);

                double total = 0;
                for (int i = 0; i < list.Count(); i++)
                {
                    total += list[i].Subtotal;
                }
                
                EntVenta venta = new EntVenta
                {
                    Cliente = usuario,
                    Total = total
                };

                int idVenta = Ventaservice.CrearVenta(venta);
                venta.IdVenta = idVenta;

                EntDetVenta det = new EntDetVenta();

                for (int i = 0; i < list.Count; i++)
                {
                    det.Venta = venta;
                    det.Producto = new EntProducto
                    {
                        IdProducto = list[i].ProveedorProducto.Producto.IdProducto
                    };
                    det.Cantidad = list[i].Cantidad;
                    det.SubTotal = list[i].Subtotal;

                    DetVentaservice.CrearDetVenta(det);
                }
                return RedirectToAction("ListarVenta");

            }
            catch
            {
                return RedirectToAction("Error", "Home");

            }
        }
    }
}
