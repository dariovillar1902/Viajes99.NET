using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCFrameworkNeoris.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe ingresar un nombre.")]
        [MaxLength(50, ErrorMessage ="Máximo para nombre: 50 caracteres")]
        [DisplayName("Nombre:")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido.")]
        [MaxLength(50, ErrorMessage = "Máximo para apellido: 50 caracteres")]
        [DisplayName("Apellido:")]
        public string apellido { get; set; }
        [DisplayName("Dirección:")]
        [MaxLength(200, ErrorMessage = "Máximo para dirección: 200 caracteres")]
        [Required(ErrorMessage = "Debe ingresar una dirección.")]
        public string direccion { get; set; }
        [DisplayName("País:")]
        [Required(ErrorMessage = "Debe seleccionar un país.")]
        public string pais { get; set; }
        [DisplayName("Provincia:")]
        [Required(ErrorMessage = "Debe seleccionar una provincia.")]
        public string provincia { get; set; }
        [DisplayName("Teléfono:")]
        [Required(ErrorMessage = "Debe ingresar un teléfono.")]
        public int telefono { get; set; }
        [DisplayName("DNI:")]
        [Required(ErrorMessage = "Debe ingresar un DNI.")]
        public int dni { get; set; }
        [DisplayName("CUIT:")]
        [Required(ErrorMessage = "Debe ingresar un CUIT.")]
        public decimal cuit { get; set; }
        [DisplayName("Razón Social:")]
        public string razonsocial { get; set; }
        [DisplayName("Tipo de Cliente:")]
        public int tipocliente { get; set; }
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
                if (dr["Direccion"] is System.DBNull)
                {
                    this.direccion = "";
                }
                else
                {
                    this.direccion = (string)dr["Direccion"];
                }

                if (dr["Apellido"] is System.DBNull)
                {
                    this.apellido = "";
                }
                else
                {
                    this.apellido = (string)dr["Apellido"];
                }

                if (dr["Pais"] is System.DBNull)
                {
                    this.pais = "";
                }
                else
                {
                    this.pais = (string)dr["Pais"];
                }

                if (dr["Provincia"] is System.DBNull)
                {
                    this.provincia = "";
                }
                else
                {
                    this.provincia = (string)dr["Provincia"];
                }

                if (dr["Telefono"] is System.DBNull)
                {
                    this.telefono = 0;
                }
                else
                {
                    this.telefono = (int)dr["Telefono"];
                }

                if (dr["DNI"] is System.DBNull)
                {
                    this.dni = 0;
                }
                else
                {
                    this.dni = (int)dr["DNI"];
                }

                if (dr["CUIT"] is System.DBNull)
                {
                    this.cuit = 0;
                }
                else
                {
                    this.cuit = (decimal)dr["CUIT"];
                }

                if (dr["RazonSocial"] is System.DBNull)
                {
                    this.razonsocial = "";
                }
                else
                {
                    this.razonsocial = (string)dr["RazonSocial"];
                }

                if (dr["TipoCliente"] is System.DBNull)
                {
                    this.tipocliente = 0;
                }
                else
                {
                    this.tipocliente = (int)dr["TipoCliente"];
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}