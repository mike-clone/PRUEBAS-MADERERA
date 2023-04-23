using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class entProducto
    {
        private int idProducto;
        private string nombre;
        private double longitud;
        private double diametro;
        private double precioVenta;
        private entTipoProducto tipo;
        private int stock;
        private bool activo;
        private entProveedorProducto proveedorProducto;
        public string NombreCompleto
        {
            get { return nombre + " - " + longitud + "MT - " + diametro + "Ø"; }
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
        public double Diametro
        {
            get { return diametro; }
            set { diametro = value; }
        }
        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
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
        

        public bool Activo { get => activo; set => activo = value; }
        public entProveedorProducto ProveedorProducto { get => proveedorProducto; set => proveedorProducto = value; }

        #endregion Get and Set
    }
}
