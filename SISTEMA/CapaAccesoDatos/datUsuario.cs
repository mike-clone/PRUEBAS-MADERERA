using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
  
    public class DatUsuario: IDatUsuario
    {
       
        #region Clientes
        //Crear
        public bool CrearCliente(EntUsuario Cli)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@correo", Cli.Correo);
                cmd.Parameters.AddWithValue("@userName", Cli.UserName);
                cmd.Parameters.AddWithValue("@pass", Cli.Pass);
                cmd.Parameters.AddWithValue("@idRol", Cli.Roll.IdRoll);
                cmd.Parameters.AddWithValue("@idubigeo", Cli.Ubigeo.IdUbigeo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    creado = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return creado;
        }
        public List<EntUsuario> ListarCliente()
        {
            SqlCommand cmd = null;
            List<EntUsuario> lista = new List<EntUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntUsuario Cli = new EntUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        Ubigeo = new EntUbigeo
                        {
                            Provincia = dr["provincia"].ToString(),
                        }
                    };

                    lista.Add(Cli);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL MOSTRAR CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            return lista;
        }

        public List<EntUsuario> BuscarCliente(string busqueda)
        {
            List<EntUsuario> lista = new List<EntUsuario>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntUsuario Cli = new EntUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    EntUbigeo u = new EntUbigeo
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
            
            return lista;
        }

        public bool EditarCliente(EntUsuario u)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", u.IdUsuario);
                cmd.Parameters.AddWithValue("@razonSocial", u.RazonSocial);
                cmd.Parameters.AddWithValue("@userName", u.UserName);
                cmd.Parameters.AddWithValue("@activo", u.Activo);
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

            return actualiza;

        }
        #endregion
        #region Administradores
        public List<EntUsuario> ListarAdministradores()
        {
            SqlCommand cmd = null;
            List<EntUsuario> lista = new List<EntUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarAdministradores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntUsuario Cli = new EntUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    EntUbigeo u = new EntUbigeo
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
            
            return lista;
        }

        public bool ActualizarAdministrador(EntUsuario ad)
        {
            SqlCommand cmd = null;
            bool actualizado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarAdministrador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", ad.IdUsuario);
                cmd.Parameters.AddWithValue("@razonSocial", ad.RazonSocial);
                cmd.Parameters.AddWithValue("@userName", ad.UserName);
                cmd.Parameters.AddWithValue("@telefono", ad.Telefono);
                cmd.Parameters.AddWithValue("@direccion", ad.Direccion);
                cmd.Parameters.AddWithValue("@activo", ad.Activo);
                cmd.Parameters.AddWithValue("@idUbigeo", ad.Ubigeo.IdUbigeo);
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

        public List<EntUsuario> BuscaraAdministradores(string busqueda)
        {
            List<EntUsuario> lista = new List<EntUsuario>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarAdministradores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntUsuario Cli = new EntUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Pass = dr["pass"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    EntUbigeo u = new EntUbigeo
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
           
            return lista;
        }
        #endregion
        #region COMPARTIDO
        public EntUsuario IniciarSesion(string campo, string contra)
        {
            SqlCommand cmd = null;
            EntUsuario c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spIniciarSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato", campo);
                cmd.Parameters.AddWithValue("@contra", Encrypt.GetSHA256(contra));
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        c = new EntUsuario
                        {
                            IdUsuario = Convert.ToInt16(dr["idUsuario"]),
                            RazonSocial = dr["razonSocial"].ToString(),
                            UserName = dr["userName"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                            Rol = (EntRol)dr["idRol"],//Convertir (castearlo) a objeto de tipo entRol
                            Activo = Convert.ToBoolean(dr["activo"]),
                        };
                        EntUbigeo ubigeo = new EntUbigeo
                        {
                            Distrito = dr["distrito"].ToString()
                        };
                        c.Ubigeo = ubigeo;
                    }
                }
            }
            catch(Exception ex) 
            {
               throw new Exception("no se encontro un suario"+ex.Message);
            }
           
            return c;
        }

        public bool EliminarUsuarios(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarUsuarios", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@idCliente", id);
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
            return eliminado;
        }
        public EntUsuario BuscarIdUsuario(int busqueda)
        {
            SqlCommand cmd = null;
            EntUsuario c = new EntUsuario();
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
                    c.Telefono = dr["telefono"].ToString();
                    c.Direccion = dr["direccion"].ToString();
                    c.Correo = dr["correo"].ToString();
                    c.UserName = dr["userName"].ToString();
                    c.Pass = dr["pass"].ToString();
                    c.Activo = Convert.ToBoolean(dr["activo"]);
                    c.Roll = new entRoll()
                    {
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    c.Ubigeo = new EntUbigeo()
                    {
                        Departamento = dr["departamento"].ToString(),
                        Provincia = dr["provincia"].ToString(),
                        Distrito = dr["distrito"].ToString()
                    };
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al buscar usuarios procedimiento spBuscarIDUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return c;
        }

        #endregion
    }

}
