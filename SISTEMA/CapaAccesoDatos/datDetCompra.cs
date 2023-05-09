using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{

    public class DatDetCompra : IDatDetCompra
    {
        public bool CrearDetCompra(EntDetCompra Det)
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

        public List<EntDetCompra> MostrarDetalleCompraId(int id)
        {
            List<EntDetCompra> list = new List<EntDetCompra>();
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
                    EntDetCompra detalle = new EntDetCompra
                    {
                        Compra = new EntCompra
                        {
                            IdCompra = Convert.ToInt32(dr["idCompra"])
                        },
                        ProveedorProducto = new EntProveedorProducto
                        {
                            Proveedor = new EntProveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                                RazonSocial = dr["razonSocial"].ToString(),
                                Descripcion = dr["descripcion"].ToString(),

                            },
                            Producto = new EntProducto
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["nombre"].ToString(),
                                Longitud = Convert.ToDouble(dr["longitud"]),
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                Tipo = new EntTipoProducto
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
