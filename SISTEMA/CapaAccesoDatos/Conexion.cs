using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();

        public static Conexion Instancia
        {
            get { return _instancia; }
        }

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = "Data Source =Mike\\SQLExpress; Initial Catalog = BD_PRUEBAS_MADERERA; Integrated Security = true";
                cn.Open();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("no se pudo conectar al servidor"+ex.Message);
            }
            return cn;
        }
    }
}
