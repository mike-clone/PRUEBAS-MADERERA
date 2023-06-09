﻿using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatTemporaryProducts : IDatTemporaryProducts
    {
        private static readonly DatTemporaryProducts _instance = new DatTemporaryProducts();
        public static DatTemporaryProducts Instance
        {
            get { return _instance; }
        }
        public bool CreaarTemporaryProductsCli(EntTemporaryProducts temp)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearTemporaryProductsCli", cn);
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
            
            return creado;

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
                cmd.Parameters.AddWithValue("@idProveedor", temp.ProveedorProducto.Proveedor.IdProveedor);
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
                        ProveedorProducto=new EntProveedorProducto
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
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                Tipo = new EntTipoProducto
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
                        ProveedorProducto = new EntProveedorProducto
                        {
                            Producto = new EntProducto
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Nombre = dr["nombre"].ToString(),
                                Longitud = Convert.ToDouble(dr["longitud"]),
                                Diametro = Convert.ToDouble(dr["diametro"]),
                                PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                Tipo = new EntTipoProducto
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
            return actualizado;
        }

        public EntTemporaryProducts BuscarTemporaryProductsId(int id)
        {
            SqlCommand cmd = null;
            EntTemporaryProducts temp = new EntTemporaryProducts();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarTemporaryProducts", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idtemp", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.IdTemp = Convert.ToInt32(dr["idtemp"]);
                    temp.ProveedorProducto = new EntProveedorProducto
                    {
                        Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonSocial"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        },
                        Producto = new EntProducto
                        {
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Tipo = new EntTipoProducto
                            {
                                IdTipo_producto= Convert.ToInt32(dr["idTipo_Producto"]),
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

            return temp;
        }
        public EntTemporaryProducts BuscarTemporaryProductsIdCli(int id)
        {
            SqlCommand cmd = null;
            EntTemporaryProducts temp = new EntTemporaryProducts();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarTemporaryProductsCli", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idtemp", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.IdTemp = Convert.ToInt32(dr["idtemp"]);
                    temp.ProveedorProducto = new EntProveedorProducto
                    {
                        Proveedor = new EntProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                            RazonSocial = dr["razonSocial"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        },
                        Producto = new EntProducto
                        {
                            Nombre = dr["nombre"].ToString(),
                            Longitud = Convert.ToDouble(dr["longitud"]),
                            Diametro = Convert.ToDouble(dr["diametro"]),
                            Tipo = new EntTipoProducto
                            {
                                IdTipo_producto = Convert.ToInt32(dr["idTipo_Producto"]),
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

            return temp;
        }
    }

}
