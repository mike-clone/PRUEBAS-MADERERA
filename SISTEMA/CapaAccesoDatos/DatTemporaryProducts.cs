using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                cmd = new SqlCommand("spCrearTemporaryProducts", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", temp.ProveedorProducto.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@idUsuario", temp.Usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@cantidad", temp.Cantidad);
                cmd.Parameters.AddWithValue("@subtotal", temp.Subtotal);
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

        public List<EntTemporaryProducts> MostrarTemporaryProducts(int idUsuario)
        {
            SqlCommand cmd = null;
            List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTemporaryProducts", cn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntTemporaryProducts temp = new EntTemporaryProducts
                    {
                        IdTemp = Convert.ToInt32(dr["idtemp"]),
                        ProveedorProducto=new entProveedorProducto
                        {
                            Proveedor = new entProveedor
                            {   
                                IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                                RazonSocial = dr["razonSocial"].ToString(),
                                Descripcion = dr["descripcion"].ToString()
                            },
                            Producto = new entProducto
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["nombre"].ToString(),
                                Longitud = Convert.ToDouble(dr["longitud"]),
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                Tipo = new entTipoProducto
                                {
                                    Nombre = dr["tipo"].ToString()
                                }

                            },
                            PrecioCompra = Convert.ToDouble(dr["precioCompra"])
                        },
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Subtotal = Convert.ToDouble(dr["subtotal"])
                    };
                    list.Add(temp);
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
            return list;
        }

        public List<EntTemporaryProducts> MostrarTemporaryProductsCli(int idUsuario)
        {
            SqlCommand cmd = null;
            List<EntTemporaryProducts> list = new List<EntTemporaryProducts>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTemporaryProductsCli", cn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntTemporaryProducts temp = new EntTemporaryProducts
                    {
                        IdTemp = Convert.ToInt32(dr["idtemp"]),
                        ProveedorProducto = new entProveedorProducto
                        {
                            Producto = new entProducto
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["nombre"].ToString(),
                                Longitud = Convert.ToDouble(dr["longitud"]),
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                Tipo = new entTipoProducto
                                {
                                    Nombre = dr["tipo"].ToString()
                                }
                            },
                        },
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Subtotal = Convert.ToDouble(dr["subtotal"])
                    };
                    list.Add(temp);
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
            return list;
        }


        public bool EliminarTemporaryProducts(int idtemp)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarTemporaryProducts", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ids", idtemp);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminado = true;
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
            return eliminado;

        }

        public bool ActualizarTemporaryProducts(EntTemporaryProducts temp)
        {
            SqlCommand cmd = null;
            bool actualizado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarTemporaryProducts", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idtemp", temp.IdTemp);
                cmd.Parameters.AddWithValue("@cantidad", temp.Cantidad);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualizado = true;
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
            return actualizado;
        }

        public EntTemporaryProducts BuscarTemporaryProductsId(int id)
        {
            SqlCommand cmd = null;
            EntTemporaryProducts temp = new EntTemporaryProducts();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarTemporaryProductsId", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idtemp", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.IdTemp = Convert.ToInt32(dr["idtemp"]);
                    temp.ProveedorProducto = new entProveedorProducto
                    {
                        Proveedor = new entProveedor
                        {
                            RazonSocial = dr["razonSocial"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        },
                        Producto = new entProducto
                        {
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Tipo = new entTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            }
                        },
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"]),


                    };

                    temp.Cantidad = Convert.ToInt32(dr["cantidad"]);
                    temp.Subtotal = Convert.ToDouble(dr["subtotal"]);

                }

            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message); 
            }
            finally { cmd.Connection.Close(); }

            return temp;
        }
    }

}
