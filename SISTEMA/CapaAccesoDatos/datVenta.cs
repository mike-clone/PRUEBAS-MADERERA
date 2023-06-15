using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatVenta : IDatVenta
    {
        private static readonly DatVenta _instancia = new DatVenta();
        public static DatVenta Instancia
        {
            get { return _instancia; }
        }
        //Crear
        public int CrearVenta(EntVenta venta)
        {
            SqlCommand cmd = null;
            int idVenta = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@total", venta.Total);
                cmd.Parameters.AddWithValue("@idUsuario", venta.Cliente.IdUsuario);
                SqlParameter id = new SqlParameter("@idventa", 0)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 1)
                {
                    idVenta = Convert.ToInt32(cmd.Parameters["@idventa"].Value);
                }
                if (idVenta == -1)
                {
                    MessageBox.Show("Id INVALIDO");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al insertar una venta procedimiento spCrearVenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return idVenta;
        }
        //Leer
        public List<EntVenta> ListarVenta(int id)
        {
            SqlCommand cmd = null;
            List<EntVenta> lista = new List<EntVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarVenta", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntVenta ven = new EntVenta
                    {
                        IdVenta = Convert.ToInt32(dr["idVenta"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Estado = dr["estado"].ToString(),
                        Cliente = new EntUsuario
                        {
                            IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        }
                    };
                    lista.Add(ven);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
           
            return lista;
        }

        public List<EntVenta> ListarTodasLasVenta()
        {
            SqlCommand cmd = null;
            List<EntVenta> lista = new List<EntVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTodasLasVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntVenta ven = new EntVenta
                    {
                        IdVenta = Convert.ToInt32(dr["idVenta"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Estado = dr["estado"].ToString(),
                        Cliente = new EntUsuario
                        {
                            Correo = dr["correo"].ToString(),
                            UserName = dr["userName"].ToString()
                        }
                    };
                    lista.Add(ven);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            
            return lista;
        }
    }
}
