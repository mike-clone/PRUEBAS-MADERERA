using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProveedor
    {
        private int idProveedor;
        private string razonSocial;
        private  string ruc;
        private  string correo;
        private  string telefono;
        private  string descripcion;
        private  bool estProveedor;
        private entUbigeo ubigeo;

       

        #region Get and Set

        public string NombreCompleto {
            get { return razonSocial+"=>"+descripcion; }
        }
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        public string Ruc
        {
            get { return ruc; }
            set { ruc = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }

        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }
        public bool EstProveedor
        {
            get { return estProveedor; }
            set { estProveedor = value; }
        }

        public entUbigeo Ubigeo {
            get {return  ubigeo; }
            set { ubigeo = value; }
        }
        #endregion Get and Set
    }
}
