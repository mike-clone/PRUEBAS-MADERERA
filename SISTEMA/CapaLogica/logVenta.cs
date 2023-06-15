using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogVenta
    {
        private static readonly LogVenta _instancia = new LogVenta();

        public static LogVenta Instancia
        {
            get { return _instancia; }
        }

        private IDatVenta VentaService;

        public LogVenta()
        {
            
        }

        public LogVenta(IDatVenta IVenta)
        {
            VentaService = IVenta;
        }

        public int CrearVenta(EntVenta v)
        {
            return VentaService.CrearVenta(v);
        }
        public List<EntVenta> ListarVenta(int id)
        {
            return VentaService.ListarVenta(id);
        }
        public List<EntVenta> ListarTodasLasVenta()
        {
            return VentaService.ListarTodasLasVenta();
        }
        
    }
}
