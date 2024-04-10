using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace interfazGrafica.Models
{
    public class SuscripcionesIndex
    {
        public int SuscripcionID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> SedeID { get; set; }
        public string Nombre { get; set; }
        public string NombreSede { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha no válido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public string TipoSuscripcion { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}