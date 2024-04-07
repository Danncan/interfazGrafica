using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace interfazGrafica.Models
{
    public class Pagos
    {
        [Required]
        [Key]
        public int PagoID { get; set; }
        public Nullable<int> SuscripcionID { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string MetodoPago { get; set; }
        public Nullable<bool> Activo { get; set; }

        public virtual Suscripciones Suscripcione { get; set; }


        public API_Crud.Pago pagosAPI()
        {
            return new API_Crud.Pago
            {
                PagoID = this.PagoID,
                SuscripcionID = this.SuscripcionID,
                FechaPago = this.FechaPago,
                Monto = this.Monto,
                MetodoPago = this.MetodoPago,
                Activo = this.Activo,
                Suscripcione = this.Suscripcione.suscripcionesAPI(),
            };
          
        }
    }
}