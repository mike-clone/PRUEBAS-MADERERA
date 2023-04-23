﻿using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SqlParameter idp = new SqlParameter("@id", 0);
                idp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idp);
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    idproducto = Convert.ToInt32(cmd.Parameters["@id"].Value);
                }
                if (idproducto == -1)
                {
                    MessageBox.Show("Id INVALIDO");
                }
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
        public List<entProducto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto Prod = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        
                        Tipo=new entTipoProducto    
                        {
                            Nombre = dr["tipo"].ToString()

                        },
                        ProveedorProducto=new entProveedorProducto
                        {
                            PrecioCompra = Convert.ToDouble(dr["precioCompra"]),
                            Proveedor = new entProveedor
                            {
                                RazonSocial = dr["razonsocial"].ToString()
                            } 
                        }

                    };
                
                    lista.Add(Prod);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"EROR AL MOSTRAR LOS PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public List<entProducto> ListarProductoParaVender()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProductoParaVender", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto Prod = new entProducto
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
                        },
                        ProveedorProducto= new entProveedorProducto
                        {
                            Proveedor = new entProveedor
                            {
                                RazonSocial = dr["razonsocial"].ToString()
                            }
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
        public bool ActualizarProducto(entProducto Prod)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", Prod.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", Prod.Nombre);
                cmd.Parameters.AddWithValue("@longitud", Prod.Longitud);
                cmd.Parameters.AddWithValue("@diametro", Prod.Diametro);
                cmd.Parameters.AddWithValue("@precioVenta", Prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@idTipo_producto", Prod.Tipo.IdTipo_producto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualiza = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        public List<entProducto> BuscarProducto(string busqueda)
        {
            List<entProducto> lista = new List<entProducto>();
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
                    entProducto Prod = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        Tipo=new entTipoProducto
                        {
                            Nombre = dr["tipo"].ToString()
                        },
                        ProveedorProducto= new entProveedorProducto
                        {
                            Proveedor=new entProveedor
                            {
                                RazonSocial = dr["razonsocial"].ToString()
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
        public List<entProducto> BuscarProductoParaVender(string busqueda)
        {
            List<entProducto> lista = new List<entProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProductoParaVender", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto Prod = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Tipo= new entTipoProducto
                        {
                            Nombre = dr["tipo"].ToString()
                        },
                        ProveedorProducto= new entProveedorProducto
                        {
                            Proveedor = new entProveedor
                            {
                                RazonSocial = dr["razonsocial"].ToString()
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
        public List<entProducto> Ordenar(int dato)
        {
            List<entProducto> lista = new List<entProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spOrdenarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato", dato);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto Prod = new entProducto();
                    Prod.IdProducto = Convert.ToInt32(dr["idproducto"]);
                    Prod.Nombre = dr["nombre"].ToString();
                    Prod.Longitud = Convert.ToDouble(dr["longitud"]);
                    Prod.PrecioVenta = Convert.ToDouble(dr["precioVenta"]);
                    Prod.Stock = Convert.ToInt32(dr["stock"]);
                    Prod.Tipo = new entTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                        Nombre = dr["tipo"].ToString()
                    };
                    Prod.ProveedorProducto = new entProveedorProducto
                    {
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"])
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

        public entProducto BuscarProductoId(int idprod)
        {
            SqlCommand cmd = null;
            entProducto Prod = new entProducto();
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

                    Prod.IdProducto = Convert.ToInt32(dr["idproducto"]);
                    Prod.Nombre = dr["nombre"].ToString();
                    Prod.Longitud = Convert.ToDouble(dr["longitud"]);
                    Prod.Diametro = Convert.ToDouble(dr["diametro"]);
                    Prod.PrecioVenta = Convert.ToDouble(dr["precioVenta"]);
                    Prod.Stock = Convert.ToInt32(dr["stock"]);
                    var tipo = new entTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                        Nombre = dr["tipo"].ToString()
                    };
                    Prod.Tipo = tipo;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Prod;
        }

    }
}