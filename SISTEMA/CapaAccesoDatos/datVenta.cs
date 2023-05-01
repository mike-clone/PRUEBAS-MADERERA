using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datVenta
    {
        private static readonly datVenta _instancia = new datVenta();
        public static datVenta Instancia
        {
            get { return _instancia; }
        }
        //Crear
        public int CrearVenta(entVenta venta)
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
            finally
            {
                cmd.Connection.Close();
            }
            return idVenta;
        }
        //Leer
        public List<entVenta> ListarVenta(int id)
        {
            SqlCommand cmd = null;
            List<entVenta> lista = new List<entVenta>();
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
                    entVenta ven = new entVenta
                    {
                        IdVenta = Convert.ToInt32(dr["idVenta"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Estado = dr["estado"].ToString(),
                        Cliente = new entUsuario
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
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public List<entVenta> ListarTodasLasVenta()
        {
            SqlCommand cmd = null;
            List<entVenta> lista = new List<entVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTodasLasVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entVenta ven = new entVenta
                    {
                        IdVenta = Convert.ToInt32(dr["idVenta"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Estado = dr["estado"].ToString(),
                        Cliente = new entUsuario
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
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        #region SIN CHEQUEAR
        ////Leer ventas Pagadas
        //public List<entVenta> ListarVentaPagada(DateTime fecha)
        //{
        //    SqlCommand cmd = null;
        //    List<entVenta> lista = new List<entVenta>();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spListarVentaPagada", cn);
        //        cmd.Parameters.AddWithValue("@fecha", fecha);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            entVenta Prod = new entVenta();
        //            Prod.IdVenta = Convert.ToInt32(dr["idVenta"]);
        //            Prod.Fecha = Convert.ToDateTime(dr["fecha"]);
        //            Prod.Total = Convert.ToDouble(dr["total"]);
        //            Prod.Estado = Convert.ToBoolean(dr["estado"]);
        //            lista.Add(Prod);
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return lista;
        //}
        ////Listar venta no pagada 
        //public List<entVenta> ListarVentaNoPagada(DateTime fecha)
        //{
        //    SqlCommand cmd = null;
        //    List<entVenta> lista = new List<entVenta>();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spListarVentaNoPagada", cn);
        //        cmd.Parameters.AddWithValue("@fecha", fecha);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            entVenta Prod = new entVenta();
        //            Prod.IdVenta = Convert.ToInt32(dr["idVenta"]);
        //            Prod.Fecha = Convert.ToDateTime(dr["fecha"]);
        //            Prod.Total = Convert.ToDouble(dr["total"]);
        //            Prod.Estado = Convert.ToBoolean(dr["estado"]);
        //            lista.Add(Prod);
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return lista;
        //}
        ////Actualizar
        //public bool ActualizarVenta(int idVenta, bool estado)
        //{
        //    SqlCommand cmd = null;
        //    bool actualizarVenta = false;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spActualizarVenta", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idVenta", idVenta);
        //        cmd.Parameters.AddWithValue("@estado", estado);
        //        cn.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        if (i > 0)
        //        {
        //            actualizarVenta = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return actualizarVenta;
        //}
        #endregion
    }
}
