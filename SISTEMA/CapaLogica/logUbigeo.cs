﻿using CapaAccesoDatos;
using CapaEntidad;
using System.Collections.Generic;
namespace CapaLogica
{

    public class logUbigeo
    {
        private static readonly logUbigeo _instancia = new logUbigeo();
        public static logUbigeo Instancia
        {
            get { return _instancia; }
        }

        public bool CrearUbigeo(entUbigeo u)
        {
            return datUbigeo.Instancia.CrearUbigeo(u);
        }
        public List<entUbigeo> ListarUbigeo()
        {
            return datUbigeo.Instancia.ListarUbigeo();
        }
        public bool ActualizarUbigeo(entUbigeo u)
        {
            return datUbigeo.Instancia.ActualizarUbigeo(u);
        }
        public bool EliminarUbigeo(int id)
        {
            return datUbigeo.Instancia.EliminarUbigeo(id);
        }
        public List<entUbigeo> ListarDistrito()
        {
            return datUbigeo.Instancia.ListarDistrito();
        }
        public List<entUbigeo> BuscarUbigeo(string busqueda)
        {
            return datUbigeo.Instancia.BuscarUbigeo(busqueda);
        }

    }
}
