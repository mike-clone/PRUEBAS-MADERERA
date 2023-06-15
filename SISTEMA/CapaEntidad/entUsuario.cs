using System;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class EntUsuario
    {

        


        #region Get and Set
        public int IdUsuario
        {
            get;
            set;
        }

        [Required(ErrorMessage = "El campo Razon Social no puede estar vacio.")]
        public string RazonSocial
        {
            get;
            set;
        }
        [RegularExpression(@"^9\d{8}$", ErrorMessage = "El campo Teléfono debe tener 9 dígitos y comenzar con 9.")]
        public string Telefono
        {
            get;
            set;
        }
        //[Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo ubigeo es obligatorio.")]
        public EntUbigeo Ubigeo { get; set; }

        public DateTime FechaCreacion {
            get; set;
        }
        [Required(ErrorMessage = "El campo correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo no es una dirección válida.")]
        public string Correo {
            get; set;
        }
        [Required(ErrorMessage = "El campo username es obligatorio.")]
        public string UserName {
            get; set;
        }
        [Required(ErrorMessage = "El campo Password no puede estar vacio.")]
        public string Pass {
            get; set;
        }
        public EntRol Rol {
            get; set;
        }
        public bool Activo {
            get; set;
        }
        //[Required(ErrorMessage = "El campo roll es obligatorio.")]
        //[Range(0, 9, ErrorMessage = "El campo Rol debe ser un dígito entero.")]
        public entRoll Roll {
            get; set;
        }
        #endregion Get and Set
    }
}
