using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace interfazGrafica.Models
{
    public class Sedes
    {
        [Required]
        [Key]
        public int SedeID { get; set; }
        [Required(ErrorMessage = "El nombre de la sede es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre de la sede debe tener entre 2 y 100 caracteres.")]
        public string NombreSede { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Ingresa un número de teléfono válido.")]
        public string Telefono { get; set; }
        public Nullable<bool> Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Suscripciones> Suscripciones { get; set; }

        public API_Crud.Sede sedeAPI()
        {
            return new API_Crud.Sede
            {
                SedeID = this.SedeID,
                NombreSede = this.NombreSede,
                Direccion = this.Direccion,
                Telefono = this.Telefono,
                Activo = this.Activo,
            };
        }

    }
}