using CapaAccesoDatos;
using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class LogProveedor
    {
        private static readonly LogProveedor _instancia = new LogProveedor();

        public static LogProveedor Instancia
        {
            get { return _instancia; }
        }
        private IDatProveedor ProveedorService;

        public LogProveedor()
        {
            
        }

        public LogProveedor(IDatProveedor IProveedor)
        {
            ProveedorService = IProveedor;
        }
        #region CRUD
        public bool CrearProveedor(EntProveedor pro)
        {
            var error = string.Empty;
            bool isValid=ValidatorHelper.TryValidateEntity(pro, out List<string> detalleDeError);
            var detalleerrors = ValidatorHelper.aString(detalleDeError);
            bool creado = false;
            try
            {
                if (isValid)
                {
                    creado= ProveedorService.CrearProveedor(pro);
                }
                else
                {
                    error = "Uno o mas parametros estan vacios";
                    throw new Exception(error);
                }

                

            }
            catch (Exception e)
            {
                throw new Exception(e.Message
                                                   + " "
                                                   + "\n"
                                                   + "Es probale que :"
                                                   + "\n"
                                                   + " "
                                                   + detalleerrors);
            }
            return creado;
        }
        public List<EntProveedor> ListarProveedor()
        {
            return ProveedorService.ListarProveedor();
        }
        public List<EntProveedor> SelectListProveedor()
        {
            return ProveedorService.SelectListProveedor();
        }
        public List<EntProveedor> SelectListProveedordat(int id)
        {
            
            return ProveedorService.SelectListProveedordat(id);
        }
        public bool ActualizarProveedor(EntProveedor pro)
        {
            var error = string.Empty;
            bool isValid = ValidatorHelper.TryValidateEntity(pro, out List<string> detalleDeError);
            var detalleerrors = ValidatorHelper.aString(detalleDeError);
            bool actualizado = false;
            try
            {
                if (isValid)
                {
                    actualizado= ProveedorService.ActualizarProveedor(pro);
                }
                else
                {
                    error = "Uno o mas parametros estan vacios";
                    throw new Exception(error);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message
                                                    + " "
                                                    + "\n"
                                                    + "Es probale que :"
                                                    + "\n"
                                                    + " "
                                                    + detalleerrors);
            }
            return actualizado;
        }
        public bool EliminarProveedor(int id)
        {
            return ProveedorService.EliminarProveedor(id);
        }
        #endregion CRUD

        public List<EntProveedor> BuscarProveedor(string busqueda)
        {
            return ProveedorService.BuscarProveedor(busqueda);
        }
        public EntProveedor BuscarIdProveedor(int idProveedor)
        {
            return ProveedorService.BuscarIdProveedor(idProveedor);
        }
    }
}
