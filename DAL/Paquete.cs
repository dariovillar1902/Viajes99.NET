using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.DAL
{
    public class Paquete
    {
        public List<Models.Paquete> getPaquetes()
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
                    command.CommandText = "getPaquetes";
                    lector=  command.ExecuteReader();
                    List<Models.Paquete> lista=new List<Models.Paquete>();
                    Models.Paquete item;
                    while (lector.Read())
                    {
                        item = new Models.Paquete();
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

        public List<Models.Paquete> getPaqueteSegunId(int id)
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
                            ParameterName ="@Id",
                            Value = id
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "getPaqueteSegunId";
                    lector = command.ExecuteReader();
                    List<Models.Paquete> lista = new List<Models.Paquete>();
                    Models.Paquete item;
                    while (lector.Read())
                    {
                        item = new Models.Paquete();
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

        public List<Models.Paquete> borrarPaquete(int id)
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
                            ParameterName ="@Id",
                            Value = id
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "borrarPaquete";
                    lector = command.ExecuteReader();
                    List<Models.Paquete> lista = new List<Models.Paquete>();
                    Models.Paquete item;
                    while (lector.Read())
                    {
                        item = new Models.Paquete();
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
        public bool IPaquetes(MVCFrameworkNeoris.Models.Paquete p)
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
                            ParameterName ="@precio",
                            Value = p.precio
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@nombre",
                            Value = p.nombre
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@tipopaquete",
                            Value = p.tipopaquete
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cotizaciondolar",
                            Value = p.cotizaciondolar
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@requierevisa",
                            Value = p.requierevisa
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@listalugares",
                            Value = p.listalugares
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cantidaddias",
                            Value = p.cantidaddias
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.DateTime,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@fechaviaje",
                            Value = p.fechaviaje
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@vigenciapaquete",
                            Value = p.vigenciapaquete
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@impuestos",
                            Value = p.impuestos
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cantidadcuotas",
                            Value = p.cantidadcuotas
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "AltaPaquete";
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

        public bool ActPaquetes(MVCFrameworkNeoris.Models.Paquete p, int id)
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
                            ParameterName ="@Id",
                            Value = id
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@precio",
                            Value = p.precio
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@nombre",
                            Value = p.nombre
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@tipopaquete",
                            Value = p.tipopaquete
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cotizaciondolar",
                            Value = p.cotizaciondolar
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@requierevisa",
                            Value = p.requierevisa
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@listalugares",
                            Value = p.listalugares
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cantidaddias",
                            Value = p.cantidaddias
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.DateTime,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@fechaviaje",
                            Value = p.fechaviaje
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@vigenciapaquete",
                            Value = p.vigenciapaquete
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@impuestos",
                            Value = p.impuestos
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cantidadcuotas",
                            Value = p.cantidadcuotas
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "ActualizacionPaquete";
                    int i = command.ExecuteNonQuery();

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