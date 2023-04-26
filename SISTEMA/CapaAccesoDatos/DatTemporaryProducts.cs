namespace CapaAccesoDatos
{
    public class DatTemporaryProducts
    {
        private static readonly DatTemporaryProducts _instance = new DatTemporaryProducts();
        public static DatTemporaryProducts Instance
        {
            get { return _instance; }
        }
        //public bool CreaarTemporaryProducts(EntTemporaryProducts temp)
        //{
        //    SqlCommand cmd = null;
        //    bool creado = false;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spCrearTemporaryProducts", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idProducto",temp.Producto.IdProducto);
        //        cmd.Parameters.AddWithValue("@idUsuacio", temp.Usuario.IdUsuario);
        //        cmd.Parameters.AddWithValue("@cantidad", temp.Cantidad);
        //        cmd.Parameters.AddWithValue("@subtotal", temp.Subtotal);
        //        cn.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        if (i > 0)
        //        {
        //            creado = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return creado;

        //}

        //public List<EntTemporaryProducts> MostrarTemporaryProducts(int idUsuario)
        //{
        //    SqlCommand cmd = null;
        //    List<EntTemporaryProducts> list = null;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spListarTemporaryProducts", cn);
        //        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            EntTemporaryProducts temp = new EntTemporaryProducts
        //            {
        //                IdTemp = Convert.ToInt32(dr["idtemp"]),
        //                Producto = new entProducto
        //                {
        //                    Nombre = dr["nombre"].ToString(),
        //                    Longitud = Convert.ToDouble(dr["longitud"]),
        //                    Diametro = Convert.ToDouble(dr["diametro"]),
        //                    PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
        //                    Tipo = new entTipoProducto
        //                    {
        //                        Nombre = dr["tipo"].ToString()
        //                    },
        //                    ProveedorProducto = new entProveedorProducto
        //                    {
        //                        Proveedor = new entProveedor
        //                        {
        //                            RazonSocial = dr["razonSocial"].ToString(),
        //                            Descripcion = dr["descripcion"].ToString()
        //                        },
        //                        PrecioCompra = Convert.ToDouble(dr["precioCompra"])

        //                    }

        //                },
        //                Cantidad = Convert.ToInt32(dr["cantidad"]),
        //                Subtotal = Convert.ToDouble(dr["subtotal"])


        //            };

        //            list.Add(temp);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return list;
        //}

        //public bool EliminarTemporaryProducts(int id)
        //{
        //    SqlCommand cmd = null;
        //    bool eliminar = false;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spEliminarTemporaryProducts", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        cmd.Parameters.AddWithValue("@idtemp", id);
        //        int i = cmd.ExecuteNonQuery();
        //        if (i != 0)
        //        {
        //            eliminar = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return eliminar;
        //}

        //public bool ActualizarTemporaryProducts(EntTemporaryProducts temp)
        //{
        //    SqlCommand cmd = null;
        //    bool actualizado = false;
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spEditarTemporaryProducts", cn)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@idtemp",temp.IdTemp);
        //        cmd.Parameters.AddWithValue("@cantidad", temp.Cantidad);
        //        cn.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        if (i > 0)
        //        {
        //            actualizado = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return actualizado;
        //}

        //public EntTemporaryProducts BuscarTemporaryProductsId(int idProveedor)
        //{
        //    SqlCommand cmd = null;
        //    EntTemporaryProducts temp = new EntTemporaryProducts();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spBuscarIdProveedor", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idtemp", idProveedor);
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            temp.IdTemp = Convert.ToInt32(dr["idtemp"]);
        //            temp.Producto = new entProducto
        //            {
        //                Nombre = dr["nombre"].ToString(),
        //                Longitud = Convert.ToDouble(dr["longitud"]),
        //                Diametro = Convert.ToDouble(dr["diametro"]),
        //                Tipo = new entTipoProducto
        //                {
        //                    Nombre = dr["tipo"].ToString()
        //                }
        //                ProveedorProducto = new entProveedorProducto
        //                {
        //                    Proveedor = new entProveedor
        //                    {
        //                        RazonSocial = dr["razonSocial"].ToString(),
        //                        Descripcion = dr["descripcion"].ToString()
        //                    },
        //                    PrecioCompra = Convert.ToDouble(dr["precioCompra"])
        //                    temp.Cantidad = Convert.ToInt32(dr["cantidad"])
        //                temp.Subtotal = Convert.ToDouble(dr["subtotal"])
        //                }

        //            };

        //        }

        //    } catch (Exception e)
        //    { throw e; }
        //    finally { cmd.Connection.Close(); }

        //    return temp;
        //}
    }

}
