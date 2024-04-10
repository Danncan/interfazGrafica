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
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El Nombre no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El nombre debe contener solo letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El Apellido no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El apellido debe contener solo letras y espacios.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingresa un formato de correo electrónico válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Ingresa un número de teléfono válido.")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)] // Especifica el tipo de dato.
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Define el formato de la fecha.

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
