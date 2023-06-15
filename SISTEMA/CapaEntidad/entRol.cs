using System;

namespace CapaEntidad
{
    public enum EntRol
    {
        // enum permite poner constantes listadas con nombre y valor
        Administrador = 1, Cliente = 2, Empleado = 3

    }
    public class entRoll
    {

        public int IdRoll { get; set; }
        public string Descripcion { get; set; }
    }
}
