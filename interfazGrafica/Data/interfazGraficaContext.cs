using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace interfazGrafica.Data
{
    public class interfazGraficaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public interfazGraficaContext() : base("name=interfazGraficaContext")
        {
        }

        public System.Data.Entity.DbSet<interfazGrafica.Models.Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<interfazGrafica.Models.Sedes> Sedes { get; set; }

        public System.Data.Entity.DbSet<interfazGrafica.Models.Pagos> Pagos { get; set; }

        public System.Data.Entity.DbSet<interfazGrafica.Models.Suscripciones> Suscripciones { get; set; }
    }
}
