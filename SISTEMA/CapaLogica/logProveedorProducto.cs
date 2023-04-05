﻿using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{

   public class logProveedorProducto
    {
        private static readonly logProveedorProducto _instancia = new logProveedorProducto();
        public static logProveedorProducto Instancia
        {
            get { return _instancia; }
        }

        public entProveedorProducto MostrarDetalleProvedorId(int idProveedor)
        {
            return  datProveedorProducto.Instancia.MostarDetalleProveedorId(idProveedor);
        }
    }
}
