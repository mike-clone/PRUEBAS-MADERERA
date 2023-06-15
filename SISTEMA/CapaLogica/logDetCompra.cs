using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace CapaLogica
{
    public class LogDetCompra
    {
        private readonly IDatDetCompra DetCompraService;
        public LogDetCompra()
        {

        }
        public LogDetCompra(IDatDetCompra idatdetcompra)
        {
            DetCompraService= idatdetcompra;
        }
      
        public bool CrearDetCompra(EntDetCompra comp)
        {
            return DetCompraService.CrearDetCompra(comp);
        }
        public List<EntDetCompra> MostrarDetalleCompraId(int id)
        {
            return DetCompraService.MostrarDetalleCompraId(id);
        }


    }
}
