using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
  public  class datProveedorProducto
    {
        private static readonly datProveedorProducto _instance = new datProveedorProducto();

        public static datProveedorProducto Instancia
        {
            get { return _instance; }
        }

        public List<entProveedorProducto> MostarDetalleProveedorId(int idProveedor)
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> list = new List<entProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spMostrarDetalleProveedorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedorProducto det = new entProveedorProducto();
                    det.IdProveedorProducto = Convert.ToInt32(dr["idProvedoor_producto"]);

                    entProveedor pro = new entProveedor();
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.Descripcion = dr["descripcion"].ToString();

                    entProducto prod = new entProducto();
                    prod.IdProducto = Convert.ToInt32(dr["idProducto"]);
                    prod.Nombre = dr["nombre"].ToString();
                    prod.Longitud = Convert.ToDouble(dr["longitud"]);
                    prod.Longitud = Convert.ToInt32(dr["stock"]);

                    det.PrecioCompra = Convert.ToDouble(dr["precioCompra"]);
                    det.Proveedor = pro;
                    det.Producto = prod;

                    list.Add(det);
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return list;
        }
    }
}
