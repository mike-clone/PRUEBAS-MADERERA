﻿using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logDetCompra
    {
        private static readonly logDetCompra _instancia = new logDetCompra();

        public static logDetCompra Instancia
        {
            get { return _instancia; }
        }
        public bool CrearDetCompra(entDetCompra comp)
        {
            return datDetCompra.Instancia.CrearDetCompra(comp);
        }
        public List<entReporteCompra> MostrarReporteCompra(int idCompra)
        {
            return datDetCompra.Instancia.MostrarReporteCompra(idCompra);
        }
        #region Carrito de Compras
        //public void AgregarProductoCarrito(entDetCompra det)
        //{
        //    datDetCompra.Instancia.AgregarProductoCarrito(det);
        //}
        //public List<entDetCompra> MostrarDetCarrito()
        //{
        //    return datDetCompra.Instancia.MostrarDetCarrito();
        //}
        //public bool EliminarDetCarrito(int id)
        //{
        //    return datDetCompra.Instancia.EliminarDetCarrito(id);
        //}
        #endregion Carrito de Compras

    }
}
