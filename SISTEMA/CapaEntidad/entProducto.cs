﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProducto
    {
        private int idProducto;
        private string nombre;
        private double longitud;
        private double precioCompra;
        private double precioVenta;
        private entTipoProducto tipo;
        private int stock;
        private entProveedor nomProv;
        //crear diametro

        public string nombreCompleto
        {
            get { return nombre + " " + longitud; } //pasar diametro tmb
        }

        #region Get and Set
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        public double PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }
        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public entTipoProducto Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public entProveedor NomProv
        {
            get { return nomProv;  }
            set { nomProv = value;  }
        }
        #endregion Get and Set
    }
}
