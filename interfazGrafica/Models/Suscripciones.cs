using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace interfazGrafica.Models
{
    public class Suscripciones
    {
        [Required]
        [Key]
        public int SuscripcionID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> SedeID { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de fecha no válido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaInicio { get; set; }

        [Required(ErrorMessage = "El tipo de suscripción es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de suscripción debe tener menos de 50 caracteres.")]
        public string TipoSuscripcion { get; set; }

        public string Estado { get; set; }
        public Nullable<bool> Activo { get; set; }

        public virtual Clientes Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Pagos> Pagos { get; set; }
        public virtual Sedes Sede { get; set; }

        public API_Crud.Suscripcione suscripcionesAPI()
        {
            return new API_Crud.Suscripcione
            {
                SuscripcionID = this.SuscripcionID,
                ClienteID = this.ClienteID,
                SedeID = this.SedeID,
                FechaInicio = this.FechaInicio,
                TipoSuscripcion = this.TipoSuscripcion,
                Estado = this.Estado,
                Activo = this.Activo,
            };
        }

    }
}