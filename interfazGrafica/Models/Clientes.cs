using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace interfazGrafica.Models
{
    public class Clientes
    {
        [Required]
        [Key]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public string Cedula { get; set; }
        public Nullable<bool> Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Suscripciones> Suscripciones { get; set; }

        

        public API_Crud.Cliente clienteAPI()
        {
            return new API_Crud.Cliente
            {
                ClienteID = this.ClienteID,
                Cedula = this.Cedula,
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Email = this.Email,
                Telefono = this.Telefono,
                FechaRegistro = this.FechaRegistro,
                Activo = this.Activo,
            };
        }

    }
}
