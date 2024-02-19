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


    public partial class reparacion : PropertyChangedDataError
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reparacion()
        {
            this.factura = new HashSet<factura>();
            this.pieza = new HashSet<pieza>();
        }

        public int idReparacion { get; set; }
        public string descripcion { get; set; }
        [Required]
        public double precio { get; set; }
        [Required(ErrorMessage = "El tipo de la reparacion es obligatorio")]
        [MaxLength(45)]
        public string tipo { get; set; }
        [Required(ErrorMessage = "El estado de la reparacion es obligatorio")]
        [MaxLength(45)]
        public string estado { get; set; }
        [Required(ErrorMessage = "La resolución de la reparacion es obligatoria. Si todavía no hay, insertar 'Resolución pendiente'")]
        [MaxLength(200)]
        public string resolucion { get; set; }
        [Required(ErrorMessage = "La fecha de recepcion de la reparacion es obligatorio")]
        public System.DateTime fechaRecepcion { get; set; }
        public Nullable<System.DateTime> fechaResolucion { get; set; }
        public string observaciones { get; set; }
        [Required]
        public int Cliente_idCliente { get; set; }
        [Required]
        public int Empleado_idEmpleado { get; set; }
        public Nullable<double> horasTrabajadas { get; set; }

        [Required]
        public virtual cliente cliente { get; set; }
        [Required]
        public virtual empleado empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pieza> pieza { get; set; }
    }
}