using MVCFrameworkNeoris.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.DAL
{
    public class Cliente
    {
        public List<Models.Cliente> getClientes()
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
                    command.CommandText = "getClientes";
                    lector=  command.ExecuteReader();
                    List<Models.Cliente> lista=new List<Models.Cliente>();
                    Models.Cliente item;
                    while (lector.Read())
                    {
                        item = new Models.Cliente();
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

        public List<Models.Cliente> getClienteSegunId(int id)
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
                    command.CommandText = "getClienteSegunId";
                    lector = command.ExecuteReader();
                    List<Models.Cliente> lista = new List<Models.Cliente>();
                    Models.Cliente item;
                    while (lector.Read())
                    {
                        item = new Models.Cliente();
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

        public List<Models.Cliente> getClienteSegunCondicion(string ruta)
        {
            var splitStr = ruta;
            char[] delimiterChars = { '&', '=' };
            string[] words = splitStr.Split(delimiterChars);

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
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@condicion",
                            Value = words[1]
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@valor",
                            Value = Int32.Parse(words[3])
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "getClienteSegunCondicion";
                    lector = command.ExecuteReader();
                    List<Models.Cliente> lista = new List<Models.Cliente>();
                    Models.Cliente item;
                    while (lector.Read())
                    {
                        item = new Models.Cliente();
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

        public List<Models.Cliente> borrarCliente(int id)
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
                    command.CommandText = "borrarCliente";
                    lector = command.ExecuteReader();
                    List<Models.Cliente> lista = new List<Models.Cliente>();
                    Models.Cliente item;
                    while (lector.Read())
                    {
                        item = new Models.Cliente();
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

        public bool IClientes(MVCFrameworkNeoris.Models.Cliente c)
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
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@apellido",
                            Value = c.apellido
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@nombre",
                            Value = c.nombre
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@direccion",
                            Value = c.direccion
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@pais",
                            Value = c.pais
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@provincia",
                            Value = c.provincia
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@telefono",
                            Value = c.telefono
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@dni",
                            Value = c.dni
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Decimal,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cuit",
                            Value = c.cuit
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@razonsocial",
                            Value = c.razonsocial
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@tipocliente",
                            Value = c.tipocliente
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "AltaCliente";
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

        public bool ActClientes(MVCFrameworkNeoris.Models.Cliente c, int id)
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
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                            ParameterName ="@apellido",
                            Value = c.apellido
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@nombre",
                            Value = c.nombre
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@direccion",
                            Value = c.direccion
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@pais",
                            Value = c.pais
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@provincia",
                            Value = c.provincia
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@telefono",
                            Value = c.telefono
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@dni",
                            Value = c.dni
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Decimal,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@cuit",
                            Value = c.cuit
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@razonsocial",
                            Value = c.razonsocial
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                             ParameterName ="@tipocliente",
                            Value = c.tipocliente
                        }
                    };
                    command.Parameters.AddRange(parametros);
                    command.CommandText = "ActualizacionCliente";
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