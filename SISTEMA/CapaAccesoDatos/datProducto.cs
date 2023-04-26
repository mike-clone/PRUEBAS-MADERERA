using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datProducto
    {
        private static readonly datProducto _instancia = new datProducto();
        public static datProducto Instancia
        {
            get { return _instancia; }
        }


        //Crear
        public int CrearProducto(entProducto prod)
        {
            SqlCommand cmd = null;
            int idproducto = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@longitud", prod.Longitud);
                cmd.Parameters.AddWithValue("@diametro", prod.Diametro);
                cmd.Parameters.AddWithValue("@precioVenta", prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@idTipo_Producto", prod.Tipo.IdTipo_producto);
                SqlParameter idp = new SqlParameter("@id", 0)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(idp);
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                    idproducto = Convert.ToInt32(cmd.Parameters["@id"].Value);
                else
                    MessageBox.Show("no se recupero el id del producto al insertar");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL INSERTAR UN PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return idproducto;

        }
        //Leer
        public List<entProveedorProducto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProducto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto Prod = new entProveedorProducto
                    {

                        Producto = new entProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Activo = Convert.ToBoolean(dr["Activo"]),

                            Tipo = new entTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()

                            }
                        }
                    };
                    if (dr["razonsocial"] != DBNull.Value)
                    {
                        Prod.Proveedor = new entProveedor
                        {
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
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public List<entProveedorProducto> ListarProductoParaVender()
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProductoParaVender", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto Prod = new entProveedorProducto
                    {
                        Producto = new entProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Tipo = new entTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            }
                        },
                        Proveedor = new entProveedor
                        {
                            RazonSocial = dr["razonsocial"].ToString()
                        }
                    };

                    lista.Add(Prod);
                }

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
        public bool ActualizarProducto(entProveedorProducto Prod)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarProducto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idProducto", Prod.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", Prod.Producto.Nombre);
                cmd.Parameters.AddWithValue("@longitud", Prod.Producto.Longitud);
                cmd.Parameters.AddWithValue("@diametro", Prod.Producto.Diametro);
                cmd.Parameters.AddWithValue("@precioVenta", Prod.Producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@idTipo_producto", Prod.Producto.Tipo.IdTipo_producto);
                cmd.Parameters.AddWithValue("@Activo", Prod.Producto.Activo);
                cmd.Parameters.AddWithValue("@idProveedor", Prod.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@precioCompra", Prod.PrecioCompra);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualiza = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("el error esta aqui" + e.Message);
            }
            finally { cmd.Connection.Close(); }
            return actualiza;
        }

        //Eliminar - Deshabilitar
        public bool EliminarProducto(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarProducto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idProducto", id);
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
            finally { cmd.Connection.Close(); }
            return eliminado;
        }

        public List<entProveedorProducto> BuscarProducto(string busqueda)
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto Prod = new entProveedorProducto
                    {
                        Producto = new entProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Activo = Convert.ToBoolean(dr["Activo"]),
                            Tipo = new entTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            },
                        },
                    };

                    if (dr["razonsocial"] != DBNull.Value)
                    {
                        Prod.Proveedor = new entProveedor
                        {
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
        public List<entProveedorProducto> BuscarProductoParaVender(string busqueda)
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProductoParaVender", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto Prod = new entProveedorProducto
                    {
                        Proveedor = new entProveedor
                        {
                            RazonSocial = dr["razonsocial"].ToString()
                        },
                        Producto = new entProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Tipo = new entTipoProducto
                            {
                                Nombre = dr["tipo"].ToString()
                            }
                        }

                    };

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
        public List<entProveedorProducto> Ordenar(int dato)
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spOrdenarProducto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@dato", dato);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto Prod = new entProveedorProducto
                    {
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"]),

                        Producto = new entProducto
                        {
                            IdProducto = Convert.ToInt32(dr["idproducto"]),
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                            Stock = Convert.ToInt32(dr["stock"]),
                            Tipo = new entTipoProducto
                            {
                                IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                                Nombre = dr["tipo"].ToString()
                            }
                        }
                    };


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

        public entProveedorProducto BuscarProductoId(int idprod)
        {
            SqlCommand cmd = null;
            entProveedorProducto Prod = new entProveedorProducto();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProductoid", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmintidProducto", idprod);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prod.Producto = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        Tipo = new entTipoProducto
                        {
                            IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                            Nombre = dr["tipo"].ToString()

                        }
                    };

                    if (dr["razonsocial"] != DBNull.Value)
                    {
                        Prod.Proveedor = new entProveedor
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