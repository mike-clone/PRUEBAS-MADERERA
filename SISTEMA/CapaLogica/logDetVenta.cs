using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;
namespace CapaLogica
{
    public class LogDetVenta
    {
        private static readonly LogDetVenta _instancia = new LogDetVenta();

        public static LogDetVenta Instancia
        {
            get { return _instancia; }
        }

        private IDatDetVenta DetVentaService;

        public LogDetVenta()
        {
            
        }

        public LogDetVenta(IDatDetVenta IDetVenta)
        {
            DetVentaService = IDetVenta;
        }

        public bool CrearDetVenta(EntDetVenta det)
        {
            return DetVentaService.CrearDetVenta(det);
        }
       
        //Carrito compras
      
        public List<EntDetVenta> Mostrardetventa(int idVenta)
        {
            return DetVentaService.Mostrardetventa(idVenta);
        }
       
    }
}
