using System;
using System.Collections.Generic;
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
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public string TipoSuscripcion { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}