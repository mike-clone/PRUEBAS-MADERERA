using System;

namespace CapaEntidad
{
    public class entDetVenta
    {
        private entVenta venta;
        private EntProducto producto;
        private int cantidad;
        private double subTotal;


        #region Get and Set
        public entVenta Venta
        {
            get { return venta; }
            set { venta = value; }
        }
        public EntProducto Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Double SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }


        #endregion Get and Set

    }
}
