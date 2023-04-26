using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logRoll
    {
        private static readonly logRoll _instancia = new logRoll();
        public static logRoll Instancia
        {
            get { return _instancia; }
        }

        public List<entRoll> ListarRol()
        {
            return datRoll.Instancia.ListarRoll();
        }
    }
}
