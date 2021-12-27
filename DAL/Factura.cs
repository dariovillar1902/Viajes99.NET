using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.DAL
{
    public class Factura
    {
        public List<Models.Factura> getFacturas()
        {
            SqlConnection dc = new SqlConnection();
            dc = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientesConn"].ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = dc;
            command.CommandType = CommandType.StoredProcedure;
            IDataReader lector=null;
            using (dc)
            {
                try
                {
                    dc.Open();
                    command.CommandText = "getFacturas";
                    lector=  command.ExecuteReader();
                    List<Models.Factura> lista=new List<Models.Factura>();
                    Models.Factura item;
                    while (lector.Read())
                    {
                        item = new Models.Factura();
                        item.CastDR(lector);
                        lista.Add(item);
                    }
                    lector.Close();
                    dc.Close();
                    dc.Dispose();
                    return lista;
                }
                catch (Exception ex)
                {
                    lector.Close();
                    dc.Close();
                    dc.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Models.Factura> getFacturaSegunId(int id)
        {
            SqlConnection dc = new SqlConnection();
            dc = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientesConn"].ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = dc;
            command.CommandType = CommandType.StoredProcedure;
            IDataReader lector = null;
            using (dc)
            {
                try
                {
                    dc.Open();
                    var parametros = new SqlParameter[]
                    {
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@id",
                            Value = id
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "getFacturaSegunId";
                    lector = command.ExecuteReader();
                    List<Models.Factura> lista = new List<Models.Factura>();
                    Models.Factura item;
                    while (lector.Read())
                    {
                        item = new Models.Factura();
                        item.CastDR(lector);
                        lista.Add(item);
                    }
                    lector.Close();
                    dc.Close();
                    dc.Dispose();
                    return lista;
                }
                catch (Exception ex)
                {
                    lector.Close();
                    dc.Close();
                    dc.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool IFacturas(MVCFrameworkNeoris.Models.Factura f)
        {
            SqlConnection dc = new SqlConnection();
            dc = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientesConn"].ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = dc;
            command.CommandType = CommandType.StoredProcedure;
            using (dc)
            {
                try
                {
                    dc.Open();
                    var parametros = new SqlParameter[]
                    {
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@paquetevendido",
                            Value = f.paquetevendido
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@clientefacturado",
                            Value = f.clientefacturado
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@ventascliente",
                            Value = f.ventascliente
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.DateTime,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@fechafactura",
                            Value = f.fechafactura
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "AltaFactura";
                    int i=command.ExecuteNonQuery();
                    
                    dc.Close();
                    if (i >= 1)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}