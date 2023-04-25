using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntTemporaryProducts
    {
        private int idTemp;
        private entProducto producto;
        private entUsuario usuario;
        private int cantidad;
        private double subtotal;

        public int IdTemp { get => idTemp; set => idTemp = value; }
        public entProducto Producto { get => producto; set => producto = value; }
        public entUsuario Usuario { get => usuario; set => usuario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
