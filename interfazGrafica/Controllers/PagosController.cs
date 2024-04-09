using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using interfazGrafica.Data;
using interfazGrafica.Logica;
using interfazGrafica.Models;
using System.Web.Caching;
using PagedList;


namespace interfazGrafica.Views.UIPagos
{
    public class PagosController : Controller
    {
        private interfazGraficaContext db = new interfazGraficaContext();
        logicaCRUD logicaCRUD = new logicaCRUD();
        logicaConsultas logicaConsultas = new logicaConsultas();
        List<Suscripciones> suscripcioneslst = new List<Suscripciones>();

        // GET: Pagos
        public ActionResult Index(int? page)
        {
            int pageSize = 10; // El número de pagos que quieres mostrar por página
            int pageNumber = (page ?? 1); // Si 'page' es null, establecer a 1

            // Asumiendo que logicaConsultas.ListarPagos() devuelve IQueryable o puede modificarse para ello
            var pagos = logicaConsultas.ListarPagos().ToPagedList(pageNumber, pageSize);

            return View(pagos);
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int id)
        {
            API_Crud.Pago pagoBuscado = logicaCRUD.buscarPago(id);
            Pagos pagofinal = new Pagos
            {
                PagoID = pagoBuscado.PagoID,
                SuscripcionID = pagoBuscado.SuscripcionID,
                FechaPago = pagoBuscado.FechaPago,
                Monto = pagoBuscado.Monto,
                MetodoPago = pagoBuscado.MetodoPago,
                Activo = pagoBuscado.Activo,
            };

            if (pagofinal == null)
            {
                return HttpNotFound();
            }
            return View(pagofinal);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            var suscripciones = ObtenerSuscripcionesDesdeCache();
            ViewBag.SuscripcionID = new SelectList(suscripciones, "SuscripcionID", "SuscripcionID");
            logicaConsultas.ActualizarCachePagos();
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagoID,SuscripcionID,FechaPago,Monto,MetodoPago,Activo")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                
                logicaCRUD.CrearPago(pagos);
                return RedirectToAction("Index");
            }
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int id)
        {
            API_Crud.Pago pagoBuscado = logicaCRUD.buscarPago(id);
            Pagos pagofinal = new Pagos
            {
                PagoID = pagoBuscado.PagoID,
                SuscripcionID = pagoBuscado.SuscripcionID,
                FechaPago = pagoBuscado.FechaPago,
                Monto = pagoBuscado.Monto,
                MetodoPago = pagoBuscado.MetodoPago,
                Activo = pagoBuscado.Activo,
            };
           
            if (pagofinal == null)
            {
                return HttpNotFound();
            }
            var suscripciones = ObtenerSuscripcionesDesdeCache();
            ViewBag.SuscripcionID = new SelectList(suscripciones, "SuscripcionID", "SuscripcionID");
            return View(pagofinal);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagoID,SuscripcionID,FechaPago,Monto,MetodoPago,Activo")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {  
                logicaCRUD.ActualizarPago(pagos);
                logicaConsultas.ActualizarCachePagos();

                return RedirectToAction("Index");
            }
            var suscripciones = ObtenerSuscripcionesDesdeCache();
            ViewBag.SuscripcionID = new SelectList(suscripciones, "SuscripcionID", "SuscripcionID");
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int id)
        {
            API_Crud.Pago pagoBuscado = logicaCRUD.buscarPago(id);
            Pagos pagosFINAL = new Pagos
            {
                PagoID = pagoBuscado.PagoID,
                SuscripcionID = pagoBuscado.SuscripcionID,
                FechaPago = pagoBuscado.FechaPago,
                Monto = pagoBuscado.Monto,
                MetodoPago = pagoBuscado.MetodoPago,
                Activo = pagoBuscado.Activo,
            };
            if (pagosFINAL == null)
            {
                return HttpNotFound();
            }
            return View(pagosFINAL);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           API_Crud.Pago pagoBuscado = logicaCRUD.buscarPago(id);
            logicaCRUD.EliminarPago(pagoBuscado.PagoID);
            logicaConsultas.ActualizarCachePagos();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public List<Models.Suscripciones> ObtenerSuscripcionesDesdeCache()
        {
            // Clave única para identificar los datos en el caché
            string cacheKey = "listaSuscripciones";

            // Intenta obtener los datos desde el caché
            var suscripciones = HttpRuntime.Cache[cacheKey] as List<Models.Suscripciones>;

            // Verifica si los datos ya están en el caché
            if (suscripciones == null)
            {
                // Los datos no están en caché, así que los cargamos
                suscripciones = logicaConsultas.ListarSuscripciones();

                // Guarda los datos en el caché para su uso futuro
                // Puedes ajustar el tiempo de expiración según las necesidades de tu aplicación
                HttpRuntime.Cache.Insert(cacheKey, suscripciones, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration);
            }

            return suscripciones;
        }

    }
}
