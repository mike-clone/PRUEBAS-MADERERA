using CapaAccesoDatos.Interfaces;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace CapaAccesoDatos
{
    public class DatTipoProducto : IDatTipoProducto
    {
        private static readonly DatTipoProducto _instancia = new DatTipoProducto();

        public static DatTipoProducto Instancia
        {
            get { return _instancia; }
        }
        public bool CrearTipoProducto(EntTipoProducto tip)
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
            return creado;

        }
        //Leer
        public List<EntTipoProducto> SelectListTipoProducto()
        {
            SqlCommand cmd = null;
            List<EntTipoProducto> lista = new List<EntTipoProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSelectListTipoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntTipoProducto tip = new EntTipoProducto();
                    tip.IdTipo_producto = Convert.ToInt32(dr["idTipo_Producto"]);
                    tip.Nombre = dr["nombre"].ToString();
                    lista.Add(tip);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS TIPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        //Actualizar
        public List<EntTipoProducto> SelectListTipoProductodat(int id)
        {
            SqlCommand cmd = null;
            List<EntTipoProducto> lista = new List<EntTipoProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSelectListTipoProductodat", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntTipoProducto tip = new EntTipoProducto
                    {
                        IdTipo_producto = Convert.ToInt32(dr["idTipo_Producto"]),
                        Nombre = dr["nombre"].ToString()
                    };
                    lista.Add(tip);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "EROR AL MOSTRAR LOS TIPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        public bool ActualizarTipoProducto(EntTipoProducto tip)
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
            return eliminado;
        }

    }
}
