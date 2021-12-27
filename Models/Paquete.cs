using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.Models
{
    public class Paquete
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="DEBE INGRESAR UN NOMBRE")]
        [DisplayName("Nombre:")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "DEBE INGRESAR UN APELLIDO")]
        [DisplayName("Precio:")]
        public int precio { get; set; }
        [DisplayName("Tipo de paquete:")]
        [Required(ErrorMessage = "DEBE INGRESAR UNA DIRECCION")]
        public int tipopaquete { get; set; }
        [DisplayName("Cotización del dólar:")]
        public int cotizaciondolar { get; set; }
        [DisplayName("Requiere visa:")]
        public int requierevisa { get; set; }
        [DisplayName("Lista de lugares:")]
        public string listalugares { get; set; }
        [DisplayName("Cantidad de días:")]
        public int cantidaddias { get; set; }
        [DisplayName("Fecha de viaje:")]
        public DateTime fechaviaje { get; set; }
        [DisplayName("Paquete vigente:")]
        public int vigenciapaquete { get; set; }
        [DisplayName("Impuestos:")]
        public int impuestos { get; set; }
        [DisplayName("Cantidad de cuotas:")]
        public int cantidadcuotas { get; set; }
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
                if (dr["Nombre"] is System.DBNull)
                {
                    this.nombre = "";
                }
                else
                {
                    this.nombre = (string)dr["Nombre"];
                }
                if (dr["Precio"] is System.DBNull)
                {
                    this.precio = 0;
                }
                else
                {
                    this.precio = (int)dr["Precio"];
                }

                if (dr["TipoPaquete"] is System.DBNull)
                {
                    this.tipopaquete = 0;
                }
                else
                {
                    this.tipopaquete = (int)dr["TipoPaquete"];
                }

                if (dr["CotizacionDolar"] is System.DBNull)
                {
                    this.cotizaciondolar = 0;
                }
                else
                {
                    this.cotizaciondolar = (int)dr["CotizacionDolar"];
                }

                if (dr["RequiereVisa"] is System.DBNull)
                {
                    this.requierevisa = 0;
                }
                else
                {
                    this.requierevisa = (int)dr["RequiereVisa"];
                }

                if (dr["ListaLugares"] is System.DBNull)
                {
                    this.listalugares = "";
                }
                else
                {
                    this.listalugares = (string)dr["ListaLugares"];
                }

                if (dr["CantidadDias"] is System.DBNull)
                {
                    this.cantidaddias = 0;
                }
                else
                {
                    this.cantidaddias = (int)dr["CantidadDias"];
                }

                if (dr["FechaViaje"] is System.DBNull)
                {
                    this.fechaviaje = DateTime.Now;
                }
                else
                {
                    this.fechaviaje = (DateTime)dr["FechaViaje"];
                }

                if (dr["VigenciaPaquete"] is System.DBNull)
                {
                    this.vigenciapaquete = 0;
                }
                else
                {
                    this.vigenciapaquete = (int)dr["VigenciaPaquete"];
                }

                if (dr["Impuestos"] is System.DBNull)
                {
                    this.impuestos = 0;
                }
                else
                {
                    this.impuestos = (int)dr["Impuestos"];
                }
                if (dr["CantidadCuotas"] is System.DBNull)
                {
                    this.cantidadcuotas = 0;
                }
                else
                {
                    this.cantidadcuotas = (int)dr["CantidadCuotas"];
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}