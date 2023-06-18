using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class EntProveedor
    {
   

        #region Get and Set

       

        public int IdProveedor
        {
            get;
            set;
        }
        [Required(ErrorMessage = "El campo Razon Social es obligatorio.")]
        public string RazonSocial
        {
            get;
            set;
        }
        [Required(ErrorMessage = "El campo Ruc es obligatorio.")]
        public string Ruc
        {
            get;
            set;
        }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email no es una dirección válida.")]
        public string Correo
        {
            get;
            set;

        }
        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        [RegularExpression(@"^9\d{8}$", ErrorMessage = "El campo Teléfono debe tener 9 dígitos y comenzar con 9.")]
        public string Telefono
        {
            get;
            set;
        }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string Descripcion
        {
            get;
            set;

        }
        public bool EstProveedor
        {
            get;
            set;
        }
        public EntUbigeo Ubigeo
        {
            get;
            set;
        }
        public string NombreCompleto
        {
            get { return RazonSocial + "::" + Descripcion; }
        }
        #endregion Get and Set
    }
}
