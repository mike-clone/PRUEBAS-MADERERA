using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class DatCompra:IDatCompra
    {
        
        //Crear
        public int CrearCompra(EntCompra comp)
        {
            SqlCommand cmd = null;
            int idCompra = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearCompra", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@total", comp.Total);
                cmd.Parameters.AddWithValue("@idUsuario", comp.Usuario.IdUsuario);
                SqlParameter id = new SqlParameter("@id", 0)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i>1)
                {
                    idCompra = Convert.ToInt32(cmd.Parameters["@id"].Value);
                }
                if (idCompra == -1)
                {
                    MessageBox.Show("Id INVALIDO");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al insertar una compra procedimiento spCrearCompra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return idCompra;
        }
        //Leer
        public List<EntCompra> ListarCompra(int id)
        {
            List<EntCompra> lista = new List<EntCompra>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCompra", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCompra objCompra = new EntCompra
                    {
                        IdCompra = Convert.ToInt32(dr["idCompra"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Usuario=new EntUsuario
                        {
                            UserName = dr["username"].ToString(),
                        },
                        Estado = dr["estado"].ToString()
                    };

                    lista.Add(objCompra);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "spListarcompra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public List<EntCompra> ListarTodasLasCompras()
        {
            List<EntCompra> lista = new List<EntCompra>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTodasLasCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCompra objCompra = new EntCompra
                    {
                        IdCompra = Convert.ToInt32(dr["idCompra"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        Total = Convert.ToDouble(dr["total"]),
                        Usuario = new EntUsuario
                        {
                            Correo = dr["correo"].ToString(),
                            UserName = dr["username"].ToString()
                        },
                        Estado = dr["estado"].ToString()
                    };

                    lista.Add(objCompra);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "spListartodascompra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        //Eliminar - Deshabilitar
        public bool EliminarCompra(int idcompra)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCompra", idcompra);
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

        public List<EntCompra> BuscarCompra(string busqueda)
        {
            List<EntCompra> lista = new List<EntCompra>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCompra Prod = new EntCompra();
                    Prod.IdCompra = Convert.ToInt32(dr["idCompra"]);
                    Prod.Fecha = Convert.ToDateTime(dr["fecha"]);
                    Prod.Total = Convert.ToDouble(dr["total"]);
                    //Prod.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    lista.Add(Prod);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return lista;
        }
    }
}
