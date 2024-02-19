//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TallerMecanico.Backend.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TallerMecanico.MVVM.Base;


    public partial class factura : PropertyChangedDataError
    {
        public int idFactura { get; set; }
        [Required(ErrorMessage = "La fecha de emisión de la factura es obligatorio")]
        public System.DateTime fechaEmision { get; set; }
        [Required(ErrorMessage = "El concepto de la factura es obligatorio")]
        [MaxLength(200)]
        public string concepto { get; set; }
        [Required]
        public int Cliente_idCliente { get; set; }
        [Required]
        public int Reparacion_idReparacion { get; set; }
        [Required(ErrorMessage = "El importe total de la factura es obligatorio")]
        public double importeTotal { get; set; }

        [Required]
        public virtual cliente cliente { get; set; }
        [Required]
        public virtual reparacion reparacion { get; set; }
    }
}