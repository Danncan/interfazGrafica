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

namespace interfazGrafica.Views.UIPagos
{
    public class PagosController : Controller
    {
        private interfazGraficaContext db = new interfazGraficaContext();
        logicaCRUD logicaCRUD = new logicaCRUD();
        logicaConsultas logicaConsultas = new logicaConsultas();

        // GET: Pagos
        public ActionResult Index()
        {
            
            return View(logicaConsultas.ListarPagos());
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
            ViewBag.SuscripcionID = new SelectList(db.Suscripciones, "SuscripcionID", "TipoSuscripcion");
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
                db.Pagos.Add(pagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SuscripcionID = new SelectList(db.Suscripciones, "SuscripcionID", "TipoSuscripcion", pagos.SuscripcionID);
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            ViewBag.SuscripcionID = new SelectList(db.Suscripciones, "SuscripcionID", "TipoSuscripcion", pagos.SuscripcionID);
            return View(pagos);
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
                db.Entry(pagos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SuscripcionID = new SelectList(db.Suscripciones, "SuscripcionID", "TipoSuscripcion", pagos.SuscripcionID);
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = db.Pagos.Find(id);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagos pagos = db.Pagos.Find(id);
            db.Pagos.Remove(pagos);
            db.SaveChanges();
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
    }
}
