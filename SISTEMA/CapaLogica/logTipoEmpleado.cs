﻿using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;
namespace CapaLogica
{
    public class logTipoEmpleado
    {
        private static readonly logTipoEmpleado _instancia = new logTipoEmpleado();

        public static logTipoEmpleado Instancia
        {
            get { return _instancia; }
        }
        #region CRUD
        public bool CrearTipoEmpleado(entTipoEmpleado tip)
        {
            return datTipoEmpleado.Instancia.crearTipoEmpleado(tip);
        }
        public List<entTipoEmpleado> ListarTipoEmpleado()
        {
            return datTipoEmpleado.Instancia.ListarTipoEmpleado();
        }
        public bool ActualizarTipoEmpleado(entTipoEmpleado tip)
        {
            return datTipoEmpleado.Instancia.ActualizarTipoEmpleado(tip);
        }
        public bool EliminarTipoEmpleado(int id)
        {
            return datTipoEmpleado.Instancia.EliminarTipoEmpleado(id);
        }
        #endregion CRUD
    }
}
