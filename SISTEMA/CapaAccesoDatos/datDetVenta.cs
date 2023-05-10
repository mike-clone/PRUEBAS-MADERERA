using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatDetVenta : IDatDetVenta
    {
        private List<EntDetVenta> detalle = new List<EntDetVenta>();
        private static readonly DatDetVenta _instancia = new DatDetVenta();
        public static DatDetVenta Instancia
        {
            get { return _instancia; }
        }

        //Crear
        public bool CrearDetVenta(EntDetVenta Det)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearDetVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", Det.Venta.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", Det.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", Det.Cantidad);
                cmd.Parameters.AddWithValue("@subTotal", Det.SubTotal);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
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

       

        public List<EntDetVenta> Mostrardetventa(int idVenta)
        {
            SqlCommand cmd = null;
            List<EntDetVenta> list = new List<EntDetVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spMostrarDetalleVentaId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntDetVenta det = new EntDetVenta
                    {
                        Venta=new EntVenta
                        {
                            IdVenta= Convert.ToInt32(dr["idVenta"])
                        },
                        Producto = new EntProducto
                        {
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            
                            Tipo = new EntTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            }
                        },
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        SubTotal = Convert.ToDouble(dr["subTotal"])
                    };
                    list.Add(det);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return list;
        }


        //public List<entReporteVenta> MostrarReporteVenta(int idVenta)
        //{

        //    SqlCommand cmd = null;
        //    var lista = new List<entReporteVenta>();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spMostrarReporteVentas", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idVenta", idVenta);
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            entReporteVenta rpVenta = new entReporteVenta();

        //            rpVenta.Codigo = Convert.ToInt32(dr["CODIGO"]);
        //            rpVenta.Cliente = dr["CLIENTE"].ToString().ToUpper();
        //            rpVenta.Fecha = Convert.ToDateTime(dr["FECHA"]);
        //            rpVenta.Descripcion = dr["DESCRIPCIÓN"].ToString().ToUpper();
        //            rpVenta.Longitud = dr["LONGITUD"].ToString();
        //            rpVenta.Cantidad = dr["CANTIDAD"].ToString();
        //            rpVenta.PrecUnitario = dr["PRECIO_UNITARIO"].ToString();
        //            rpVenta.SubTotal = Convert.ToDouble(dr["SUBTOTAL"]);

        //            lista.Add(rpVenta);
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
    }
}
