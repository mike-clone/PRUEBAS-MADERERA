using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatProducto : IDatProducto
    {
        private static readonly DatProducto _instancia = new DatProducto();
        public static DatProducto Instancia
        {
            get { return _instancia; }
        }

        public bool CrearProducto(EntProducto prod)
        {
            SqlCommand cmd = null;
            bool creado = false;
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
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                    creado = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL INSERTAR UN PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;

        }

        public List<EntProducto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<EntProducto> lista = new List<EntProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntProducto Prod = new EntProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        Stock = Convert.ToInt32(dr["stock"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Tipo = new entTipoProducto
                        {
                            Nombre = dr["tipo"].ToString()
                        }
                    };

                    lista.Add(Prod);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return lista;
        }
        public bool ActualizarProducto(EntProducto Prod)
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
                cmd.Parameters.AddWithValue("@idProducto",Prod.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", Prod.Nombre);
                cmd.Parameters.AddWithValue("@longitud", Prod.Longitud);
                cmd.Parameters.AddWithValue("@diametro", Prod.Diametro);
                cmd.Parameters.AddWithValue("@precioVenta", Prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@idTipo_producto", Prod.Tipo.IdTipo_producto);
                cmd.Parameters.AddWithValue("@Activo", Prod.Activo);
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

        public List<EntProducto> BuscarProducto(string busqueda)
        {
            List<EntProducto> lista = new List<EntProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProducto", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntProducto Prod = new EntProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idproducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Longitud = Convert.ToDouble(dr["longitud"]),
                        Diametro = Convert.ToDouble(dr["diametro"]),
                        Stock = Convert.ToInt32(dr["stock"]),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Tipo = new entTipoProducto
                        {
                            Nombre = dr["tipo"].ToString()
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

        public EntProducto BuscarProductoId(int idprod)
        {
            SqlCommand cmd = null;
            EntProducto Prod = new EntProducto();
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
                    Prod.Activo = Convert.ToBoolean(dr["Activo"]);
                    Prod.Tipo = new entTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(dr["idTipo_producto"]),
                        Nombre = dr["tipo"].ToString()

                    };
                    
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return Prod;
        }

        #region SIN REVISAR
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

                        Producto = new EntProducto
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
        #endregion 

    }
}