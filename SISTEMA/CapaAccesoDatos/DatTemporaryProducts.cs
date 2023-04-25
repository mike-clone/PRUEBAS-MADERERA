using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatTemporaryProducts
    {
        private static readonly DatTemporaryProducts _instance = new DatTemporaryProducts();
        public static DatTemporaryProducts Instance
        {
            get { return _instance; }
        }
        public bool CreaarTemporaryProducts(EntTemporaryProducts temp)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", pro.RazonSocial);
                cmd.Parameters.AddWithValue("@ruc", pro.Ruc);
                cmd.Parameters.AddWithValue("@correo", pro.Correo);
                cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
                cmd.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                cmd.Parameters.AddWithValue("@estProveedor", pro.EstProveedor);
                cmd.Parameters.AddWithValue("@idUbigeo", pro.Ubigeo.IdUbigeo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    creado = true;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;
          
        }
    }
}
