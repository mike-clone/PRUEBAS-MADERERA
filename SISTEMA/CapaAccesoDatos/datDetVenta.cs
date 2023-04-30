using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datDetVenta
    {
        private List<entDetVenta> detalle = new List<entDetVenta>();
        private static readonly datDetVenta _instancia = new datDetVenta();
        public static datDetVenta Instancia
        {
            get { return _instancia; }
        }

        //Crear
        public bool CrearDetVenta(entDetVenta Det)
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

        public bool Llenardetventa(entDetVenta Det)
        {
            bool creado = false;
            try
            {
                detalle.Add(Det);
                creado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return creado;
        }

        public List<entDetVenta> Mostrardetventa(int idVenta)
        {
            SqlCommand cmd = null;
            List<entDetVenta> list = new List<entDetVenta>();
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
                    entDetVenta det = new entDetVenta
                    {
                        IdDetventa = Convert.ToInt32(dr["idVenta"]),
                        Producto = new entProducto
                        {
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            PrecioVenta = Convert.ToInt32(dr["precioVenta"]),
                            
                            Tipo = new entTipoProducto
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
                throw e; 
            }
            finally { cmd.Connection.Close(); }
            return list;
        }

        public bool Eliminardetalle(int id)
        {
            bool eliminado = false;
            try
            {
                for (int i = 0; i < detalle.Count(); i++)
                {
                    if (detalle[i].Producto.IdProducto.Equals(id))
                    {
                        detalle.RemoveAt(i);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return eliminado;

        }

        public List<entReporteVenta> MostrarReporteVenta(int idVenta)
        {

            SqlCommand cmd = null;
            var lista = new List<entReporteVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spMostrarReporteVentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entReporteVenta rpVenta = new entReporteVenta();

                    rpVenta.Codigo = Convert.ToInt32(dr["CODIGO"]);
                    rpVenta.Cliente = dr["CLIENTE"].ToString().ToUpper();
                    rpVenta.Fecha = Convert.ToDateTime(dr["FECHA"]);
                    rpVenta.Descripcion = dr["DESCRIPCIÓN"].ToString().ToUpper();
                    rpVenta.Longitud = dr["LONGITUD"].ToString();
                    rpVenta.Cantidad = dr["CANTIDAD"].ToString();
                    rpVenta.PrecUnitario = dr["PRECIO_UNITARIO"].ToString();
                    rpVenta.SubTotal = Convert.ToDouble(dr["SUBTOTAL"]);

                    lista.Add(rpVenta);
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

        //public List<EntTemporaryProducts> MostrarCarrito(int idUsuario)
        //{
        //    SqlCommand cmd = null;
        //    List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spMostrarCarrito", cn);
        //        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            EntTemporaryProducts temp = new EntTemporaryProducts
        //            {
        //                IdTemp = Convert.ToInt32(dr["idtemp"]),
        //                ProveedorProducto = new entProveedorProducto
        //                {
        //                    Producto = new entProducto
        //                    {
        //                        IdProducto = Convert.ToInt32(dr["idProducto"]),
        //                        Nombre = dr["nombre"].ToString(),
        //                        Longitud = Convert.ToDouble(dr["longitud"]),
        //                        Diametro = Convert.ToDouble(dr["diametro"]),
        //                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
        //                        Tipo = new entTipoProducto
        //                        {
        //                            Nombre = dr["tipo"].ToString()
        //                        }

        //                    },
        //                },
        //                Cantidad = Convert.ToInt32(dr["cantidad"]),
        //                Subtotal = Convert.ToDouble(dr["subtotal"])
        //            };
        //            list.Add(temp);
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
        //    return list;
        //}
        //Actualizar
        //Eliminar - Deshabilitar
    }
}
