﻿using System;

namespace CapaEntidad
{
    public class entCompra
    {
        private int idCompra;
        private DateTime fecha;
        private double total;
        private entProveedor proveedor;
        private string estado;


        #region Constructores
        public entCompra()
        {
        }

        #endregion Constructores

        #region Get and Set
        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public entProveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public string Estado { get => estado; set => estado = value; }
        #endregion Get and Set
    }
}
