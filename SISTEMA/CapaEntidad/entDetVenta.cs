using System;

namespace CapaEntidad
{
    public class EntDetVenta
    {
       


        #region Get and Set
        public EntVenta Venta
        {
            get;
            set;
        }
        public EntProducto Producto
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }

        public Double SubTotal
        {
            get;
            set;
        }


        #endregion Get and Set

    }
}
