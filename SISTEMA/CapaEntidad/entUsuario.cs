using System;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class EntUsuario
    {

        private int idUsuario;
        private string razonSocial;
        private string telefono;
        private string direccion;
        private EntUbigeo ubigeo;
        private DateTime fechaCreacion;
        private string correo;
        private string userName;
        private string pass;
        private EntRol rol;
        private entRoll roll;
        private bool activo;


        #region Get and Set
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        [Required(ErrorMessage = "El campo Razon Social no puede estar vacio.")]
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        [RegularExpression(@"^9\d{8}$", ErrorMessage = "El campo Teléfono debe tener 9 dígitos y comenzar con 9.")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        //[Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [Required(ErrorMessage = "El campo ubigeo es obligatorio.")]
        public EntUbigeo Ubigeo
        {
            get { return ubigeo; }
            set { ubigeo = value; }
        }

        public DateTime FechaCreacion {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        [Required(ErrorMessage = "El campo correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo no es una dirección válida.")]
        public string Correo { 
            get { return correo; }
            set { correo = value; }
        }
        [Required(ErrorMessage = "El campo username es obligatorio.")]
        public string UserName {
            get { return userName; }
            set { userName = value; }
        }
        [Required(ErrorMessage = "El campo Password no puede estar vacio.")]
        public string Pass {
            get { return pass; }
            set { pass = value; }
        }
        public EntRol Rol { 
            get{ return rol;}
            set{ rol = value;}
        }
        public bool Activo {
            get { return activo; }
            set { activo = value; }
        }
        //[Required(ErrorMessage = "El campo roll es obligatorio.")]
        //[Range(0, 9, ErrorMessage = "El campo Rol debe ser un dígito entero.")]
        public entRoll Roll {
            get { return roll; }
            set { roll = value; }

        }
        #endregion Get and Set
    }
}
