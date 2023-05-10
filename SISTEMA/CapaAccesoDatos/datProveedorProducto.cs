using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatProveedorProducto : IDatProveedorProducto
    {
        private static readonly DatProveedorProducto _instance = new DatProveedorProducto();

        public static DatProveedorProducto Instancia
        {
            get { return _instance; }
        }

      
        public bool CrearProveedorProducto(EntProveedorProducto prod)
        {
            SqlCommand cmd = null;
            bool crear = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearProveedorProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", prod.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@idProducto", prod.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@precioCompra", prod.PrecioCompra);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    crear = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL INSERTAR EL DETALLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return crear;
        }

        public List<EntProveedorProducto> ListarProductoParaComprar()
        {
            SqlCommand cmd = null;
            List<EntProveedorProducto> lista = new List<EntProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProductoParaComprar", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProveedorProducto Prod = new EntProveedorProducto
                    {

                        Producto = new EntProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Activo = Convert.ToBoolean(dr["Activo"]),

                            Tipo = new EntTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()

                            }
                        },
                        Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonsocial"].ToString()
                        },
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"])
                    };
                    lista.Add(Prod);
                };

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

  
        public List<EntProveedorProducto> MostarDetalleProveedorId(int idProveedor)
        {
            SqlCommand cmd = null;
            List<EntProveedorProducto> list = new List<EntProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spMostrarDetalleProveedorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProveedorProducto det = new EntProveedorProducto
                    {
                        Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonSocial"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        },
                        Producto = new EntProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idProducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Stock = Convert.ToInt32(dr["stock"])
                        },

                        PrecioCompra = Convert.ToDouble(dr["precioCompra"]),
                     };

                    list.Add(det);
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return list;
        }

        public bool EliminarDetalleProveedor(int prov, int prod)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarDetalleProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproveedor", prov);
                cmd.Parameters.AddWithValue("@idproducto", prod);
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

        public List<EntProveedorProducto> BuscarProductoParaComprar(string busqueda)
        {
            List<EntProveedorProducto> lista = new List<EntProveedorProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProductoParaComprar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProveedorProducto Prod = new EntProveedorProducto
                    {
                        Producto = new EntProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Activo = Convert.ToBoolean(dr["Activo"]),
                            Tipo = new EntTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            },
                        },
                    };

                    if (dr["razonsocial"] != DBNull.Value)
                    {
                        Prod.Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonsocial"].ToString()
                        };
                    }
                    if (dr["precioCompra"] != DBNull.Value)
                        Prod.PrecioCompra = Convert.ToDouble(dr["precioCompra"]);
                    lista.Add(Prod);
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

        public EntProveedorProducto BuscarProvedorProductoId(int idprod, int idprov)
        {
            SqlCommand cmd = null;
            EntProveedorProducto Prod = new EntProveedorProducto();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProvedorProductoId", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmintidProducto", idprod);
                cmd.Parameters.AddWithValue("@prmintidProveedor", idprov);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prod.Producto = new EntProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        Tipo = new EntTipoProducto
                        {
                            IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                            Nombre = dr["tipo"].ToString()

                        }
                    };

                    if (dr["razonsocial"] != DBNull.Value)
                    {
                        Prod.Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonsocial"].ToString()
                        };
                    }
                    if (dr["precioCompra"] != DBNull.Value)
                        Prod.PrecioCompra = Convert.ToDouble(dr["precioCompra"]);


                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return Prod;
        }
    }
}
