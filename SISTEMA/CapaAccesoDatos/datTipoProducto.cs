﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
namespace CapaAccesoDatos
{
    public class datTipoProducto
    {
        private static readonly datTipoProducto _instancia = new datTipoProducto();

        public static datTipoProducto Instancia
        {
            get { return _instancia; }
        }
        public bool CrearTipoProducto(entTipoProducto tip)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearTipoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", tip.Nombre);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    creado = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL INSERTAR UN TIPO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;

        }
        //Leer
        public List<entTipoProducto> ListarTipoProducto()
        {
            SqlCommand cmd = null;
            List<entTipoProducto> lista = new List<entTipoProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTipoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTipoProducto tip = new entTipoProducto();
                    tip.IdTipo_producto = Convert.ToInt32(dr["idTipo_Producto"]);
                    tip.Nombre = dr["nombre"].ToString();
                    lista.Add(tip);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS TIPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        //Actualizar

        public bool ActualizarTipoProducto(entTipoProducto tip)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spActualizarTipoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipo_Producto", tip.IdTipo_producto);
                cmd.Parameters.AddWithValue("@nombre", tip.Nombre);
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
        public bool EliminarTipoProducto(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarTipoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipo_Empleado", id);
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

    }
}
