﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datProveedor
    {
        private static readonly datProveedor _instance = new datProveedor();
        public static datProveedor Instancia
        {
            get { return _instance; }
        }


        //Crear
        public bool CrearProveedor(entProveedor pro)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", pro.RazonSocial);
                cmd.Parameters.AddWithValue("@ruc", pro.Ruc);
                cmd.Parameters.AddWithValue("@correo", pro.Correo);
                cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
                cmd.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                cmd.Parameters.AddWithValue("@estProveedor", pro.EstProveedor);
                cmd.Parameters.AddWithValue("@idUbigeo", pro.Ubigeo.IdUbigeo);
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
        //Leer
        public List<entProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<entProveedor> list = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                        RazonSocial = dr["razonSocial"].ToString(),
                        Ruc = dr["ruc"].ToString(),
                        Correo = dr["correo"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        EstProveedor = Convert.ToBoolean(dr["estProveedor"])
                    };

                    entUbigeo ubi = new entUbigeo
                    {
                        Departamento = dr["departamento"].ToString(),
                        Provincia = dr["provincia"].ToString(),
                        Distrito = dr["distrito"].ToString()
                    };

                    pro.Ubigeo = ubi;
                    list.Add(pro);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + "aqui es el error");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;
        }
        //Actualizar
        public List<entProveedor> SelectListProveedor()
        {
            SqlCommand cmd = null;
            var list = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSelectListProveedor", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                        RazonSocial = dr["razonSocial"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    list.Add(pro);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + "aqui es el error");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;

        }
        
        public bool ActualizarProveedor(entProveedor pro)
        {
            SqlCommand cmd = null;
            bool actualizado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarProveedor", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idProveedor", pro.IdProveedor);
                cmd.Parameters.AddWithValue("@razonSocial", pro.RazonSocial);
                cmd.Parameters.AddWithValue("@ruc", pro.Ruc);
                cmd.Parameters.AddWithValue("@correo", pro.Correo);
                cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
                cmd.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                cmd.Parameters.AddWithValue("@estProveedor", pro.EstProveedor);
                cmd.Parameters.AddWithValue("@idUbigeo", pro.Ubigeo.IdUbigeo);
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
        //Eliminar
        public bool EliminarProveedor(int idProveedor)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
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

        public List<entProveedor> SelectListProveedordat(int idprov)
        {
            SqlCommand cmd = null;
            var list = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSelectListProveedordat", cn)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@idpr",idprov);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                        RazonSocial = dr["razonSocial"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    list.Add(pro);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + "aqui es el error");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;

        }

        public List<entProveedor> BuscarProveedor(string busqueda)
        {
            List<entProveedor> list = new List<entProveedor>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor();
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.Ruc = dr["ruc"].ToString();
                    pro.Correo = dr["correo"].ToString();
                    pro.Telefono = dr["telefono"].ToString();
                    pro.Descripcion = dr["descripcion"].ToString();
                    pro.EstProveedor = Convert.ToBoolean(dr["estProveedor"]);
                    entUbigeo ubi = new entUbigeo();
                    ubi.Departamento = dr["departamento"].ToString();
                    ubi.Provincia = dr["provincia"].ToString();
                    ubi.Distrito = dr["distrito"].ToString();
                    pro.Ubigeo = ubi;
                    list.Add(pro);
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
        public entProveedor BuscarIdProveedor(int idProveedor)
        {
            SqlCommand cmd = null;
            entProveedor pro = new entProveedor();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarIdProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.Ruc = dr["ruc"].ToString();
                    pro.Correo = dr["correo"].ToString();
                    pro.Telefono = dr["telefono"].ToString();
                    pro.Descripcion = dr["descripcion"].ToString();
                    pro.EstProveedor = Convert.ToBoolean(dr["estProveedor"]);
                    entUbigeo ubi = new entUbigeo();
                    ubi.Departamento = dr["departamento"].ToString();
                    ubi.Provincia = dr["provincia"].ToString();
                    ubi.Distrito = dr["distrito"].ToString();
                    pro.Ubigeo = ubi;
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return pro;
        }


    }
}
