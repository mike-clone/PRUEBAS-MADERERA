using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class EntProveedor
    {
        private int idProveedor;
        private string razonSocial;
        private string ruc;
        private string correo;
        private string telefono;
        private string descripcion;
        private bool estProveedor;
        private EntUbigeo ubigeo;



        #region Get and Set

        public string NombreCompleto
        {
            get { return razonSocial + "::" + descripcion; }
        }

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        [Required(ErrorMessage = "El campo Razon Social es obligatorio.")]
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        [Required(ErrorMessage = "El campo Ruc es obligatorio.")]
        public string Ruc
        {
            get { return ruc; }
            set { ruc = value; }
        }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email no es una dirección válida.")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }

        }
        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        [RegularExpression(@"^9\d{8}$", ErrorMessage = "El campo Teléfono debe tener 9 dígitos y comenzar con 9.")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
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
        public EntUbigeo Ubigeo
        {
            get { return ubigeo; }
            set { ubigeo = value; }
        }
        #endregion Get and Set
    }
}
