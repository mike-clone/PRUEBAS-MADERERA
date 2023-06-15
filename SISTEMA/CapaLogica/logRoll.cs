using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogRoll
    {
        private static readonly LogRoll _instancia = new LogRoll();
        public static LogRoll Instancia
        {
            get { return _instancia; }
        }

        public List<entRoll> ListarRol()
        {
            return DatRoll.Instancia.ListarRoll();
        }
    }
}
