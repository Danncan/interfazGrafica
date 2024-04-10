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
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha no válido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaPago { get; set; }
        [Range(0.01, 1000000.00, ErrorMessage = "El monto debe ser mayor que 0 y menor o igual que 1,000,000.")]

        public Nullable<decimal> Monto { get; set; }
        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [RegularExpression("(TarjetaDeCredito|Efectivo|Transferencia)", ErrorMessage = "Método de pago no válido.")]
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
            };
          
        }
    }
}