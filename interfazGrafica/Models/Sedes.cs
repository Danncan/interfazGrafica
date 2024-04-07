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
        public string NombreSede { get; set; }
        public string Direccion { get; set; }
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