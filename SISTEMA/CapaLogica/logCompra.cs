using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;
using System.Data;

namespace CapaLogica
{
    public class LogCompra
    {
        
        private readonly IDatCompra CompraService;
        public LogCompra()
        {

        }
        public LogCompra(IDatCompra ICompra)
        {
            CompraService = ICompra;
        }

        public int CrearCompra(EntCompra comp)
        {
            return CompraService.CrearCompra(comp);
        }
        public List<EntCompra> ListarCompra(int id)
        {
            return CompraService.ListarCompra(id);
        }
        public List<EntCompra> ListartodasLasCompras()
        {
            return CompraService.ListarTodasLasCompras();
        }
        public bool EliminarCompra(int comp)
        {
            return CompraService.EliminarCompra(comp);
        }
  
        public List<EntCompra> BuscarCompra(string busqueda)
        {
            return CompraService.BuscarCompra(busqueda);
        }
    }
}
