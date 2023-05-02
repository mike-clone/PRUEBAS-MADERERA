using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datDetCompra
    {
       
        private static readonly datDetCompra _instancia = new datDetCompra();
        public static datDetCompra Instancia
        {
            get { return _instancia; }
        }

        public bool CrearDetCompra(entDetCompra Det)
        {

            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearDetCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCompra", Det.Compra.IdCompra);
                cmd.Parameters.AddWithValue("@idProveedor", Det.ProveedorProducto.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@idProducto", Det.ProveedorProducto.Producto.IdProducto);//revisar si se llena el obj completo
                cmd.Parameters.AddWithValue("@cantidad", Det.Cantidad);
                cmd.Parameters.AddWithValue("@subTotal", Det.Subtotal);
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

        public List<entDetCompra> MostrarDetalleCompraId(int id)
        {
            List<entDetCompra> list = new List<entDetCompra>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarDetalleCompraId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCompra", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entDetCompra detalle = new entDetCompra
                    {
                        Compra = new entCompra
                        {
                            IdCompra = Convert.ToInt32(dr["idCompra"])
                        },
                        ProveedorProducto = new entProveedorProducto
                        {
                            Proveedor = new entProveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                                RazonSocial = dr["razonSocial"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),

                            },
                            Producto = new entProducto
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["nombre"].ToString(),
                                Longitud = Convert.ToDouble(dr["longitud"]),
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                Tipo = new entTipoProducto
                                {
                                    Nombre = dr["tipo"].ToString()
                                }

                            },
                            PrecioCompra = Convert.ToDouble(dr["precioCompra"])
                        },
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Subtotal = Convert.ToDouble(dr["subTotal"])

                    };
                    list.Add(detalle);
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
    }
}
