﻿using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class datUsuario
    {
        private static readonly datUsuario _instacia = new datUsuario();

        public static datUsuario Instacia
        {
            get { return _instacia; }
        }
        #region CRUD
        //Crear
        public bool CrearCliente(entUsuario Cli)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Cli.Direccion);
                cmd.Parameters.AddWithValue("@idUbigeo", Cli.Ubigeo.IdUbigeo);
                cmd.Parameters.AddWithValue("@correo", Cli.Correo);
                cmd.Parameters.AddWithValue("@userName", Cli.UserName);
                cmd.Parameters.AddWithValue("@pass", Cli.Pass);
                cmd.Parameters.AddWithValue("@idRol", Cli.Roll.IdRoll);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >0 )
                    creado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL INGRESAR UN CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;
        }

        //Leer
        public List<entUsuario> ListarCliente()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario Cli = new entUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    entUbigeo u = new entUbigeo
                    {
                        Provincia = dr["provincia"].ToString(),
                    };
                   
                    Cli.Ubigeo = u;
                    lista.Add(Cli);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL MOSTRAR CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        //Actualizar

        public bool ActualizarCliente(entUsuario Cli)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", Cli.IdUsuario);
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualiza = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al modificar Cliente procedimiento spActualizarCliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { 
                cmd.Connection.Close(); 
            }
            return actualiza;
        }

        //Eliminar - Deshabilitar

        public bool EliminarCliente(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminado = true;
                }
            }
            catch (Exception e)
            {
               
                MessageBox.Show(e.Message, "Error al Eliminar Cliente procedimiento spEliminarCliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cmd.Connection.Close(); }
            return eliminado;
        }
        #endregion CRUD

        #region OTROS
        public entUsuario IniciarSesion(string campo, string contra)
        {
            SqlCommand cmd = null;
            entUsuario c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spIniciarSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato", campo);
                cmd.Parameters.AddWithValue("@contra", encrypt.GetSHA256(contra));
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        c = new entUsuario
                        {
                            IdUsuario = Convert.ToInt16(dr["idUsuario"]),
                            UserName = dr["userName"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Rol = (entRol)dr["idRol"],//Convertir (castearlo) a objeto de tipo entRol
                            Activo = Convert.ToBoolean(dr["activo"]),                       
                            RazonSocial = dr["razonSocial"].ToString(),
                            Dni = dr["dni"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Direccion = dr["direccion"].ToString(),         

                        };
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { 
                cmd.Connection.Close(); 
            }
            return c;
        }

        public List<entUsuario> BuscarCliente(string busqueda)
        {
            List<entUsuario> lista = new List<entUsuario>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarUsuario", cn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda );
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario Cli = new entUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    entUbigeo u = new entUbigeo
                    {
                        Provincia = dr["provincia"].ToString(),
                    };
                    Cli.Ubigeo = u;
                    lista.Add(Cli);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error al buscar Clientes procedimiento spBuscarCliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public entUsuario BuscarIdCliente(int busqueda)
        {
            SqlCommand cmd = null;
            entUsuario c = new entUsuario();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarIdUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    c.RazonSocial = dr["razonsocial"].ToString();
                    c.Dni = dr["dni"].ToString();
                    c.Telefono = dr["telefono"].ToString();
                    c.Direccion = dr["direccion"].ToString();
                    c.Correo = dr["correo"].ToString();
                    c.UserName = dr["userName"].ToString();
                    c.Pass = dr["pass"].ToString();
                    c.Activo = Convert.ToBoolean(dr["activo"]);

                    entUbigeo ubi = new entUbigeo
                    {
                        Distrito = dr["distrito"].ToString()
                    };
                    //entRoll roll = new entRoll
                    //{
                    //    Descripcion = dr["descripcion"].ToString()
                    //};
                    //c.Roll = roll;
                    c.Ubigeo = ubi;
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return c;
        }
    }
    #endregion OTROS
}
