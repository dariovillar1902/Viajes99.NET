using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.Models
{
   
    public class Factura
    {
        
        [Key]
        public int Id { get; set; }
        [DisplayName("Paquete vendido:")]
        public int paquetevendido { get; set; }
        [DisplayName("Cliente facturado:")]
        public int clientefacturado { get; set; }
        [DisplayName("Precio del viaje:")]
        public int ventascliente { get; set; }
        [DisplayName("Fecha de Facturación:")]
        public DateTime fechafactura { get; set; }
        public virtual void CastDR(IDataReader dr)
        {
            try
            {
                if (dr["Id"] is System.DBNull)
                {
                    this.Id = 0;
                }
                else
                {
                    this.Id = (int)dr["Id"];
                }
                if (dr["PaqueteVendido"] is System.DBNull)
                {
                    this.paquetevendido = 0;
                }
                else
                {
                    this.paquetevendido = (int)dr["PaqueteVendido"];
                }
                if (dr["ClienteFacturado"] is System.DBNull)
                {
                    this.clientefacturado = 0;
                }
                else
                {
                    this.clientefacturado = (int)dr["ClienteFacturado"];
                }

                if (dr["VentasCliente"] is System.DBNull)
                {
                    this.ventascliente = 0;
                }
                else
                {
                    this.ventascliente = (int)dr["VentasCliente"];
                }

                if (dr["FechaFactura"] is System.DBNull)
                {
                    this.fechafactura = DateTime.Now;
                }
                else
                {
                    this.fechafactura = (DateTime)dr["FechaFactura"];
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}