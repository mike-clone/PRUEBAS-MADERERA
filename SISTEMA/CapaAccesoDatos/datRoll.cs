using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatRoll
    {
        private static readonly DatRoll _instancia = new DatRoll();
        public static DatRoll Instancia
        {
            get { return _instancia; }
        }

        public List<entRoll> ListarRoll()
        {
            SqlCommand cmd = null;
            List<entRoll> lista = new List<entRoll>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRoll rol = new entRoll
                    {
                        IdRoll = Convert.ToInt32(dr["idRol"]),
                        Descripcion = dr["descripcion"].ToString(),
                    };

                    lista.Add(rol);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS ROL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
    }
}
