using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using interfazGrafica.Data;
using interfazGrafica.Models;

namespace interfazGrafica.Views.UISuscripciones
{
    public class SuscripcionesController : Controller
    {
        private interfazGraficaContext db = new interfazGraficaContext();

        // GET: Suscripciones
        public ActionResult Index()
        {
            var suscripciones = db.Suscripciones.Include(s => s.Cliente).Include(s => s.Sede);
            return View(suscripciones.ToList());
        }

        // GET: Suscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            return View(suscripciones);
        }

        // GET: Suscripciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre");
            ViewBag.SedeID = new SelectList(db.Sedes, "SedeID", "NombreSede");
            return View();
        }

        // POST: Suscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuscripcionID,ClienteID,SedeID,FechaInicio,TipoSuscripcion,Estado,Activo")] Suscripciones suscripciones)
        {
            if (ModelState.IsValid)
            {
                db.Suscripciones.Add(suscripciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", suscripciones.ClienteID);
            ViewBag.SedeID = new SelectList(db.Sedes, "SedeID", "NombreSede", suscripciones.SedeID);
            return View(suscripciones);
        }

        // GET: Suscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", suscripciones.ClienteID);
            ViewBag.SedeID = new SelectList(db.Sedes, "SedeID", "NombreSede", suscripciones.SedeID);
            return View(suscripciones);
        }

        // POST: Suscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuscripcionID,ClienteID,SedeID,FechaInicio,TipoSuscripcion,Estado,Activo")] Suscripciones suscripciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suscripciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nombre", suscripciones.ClienteID);
            ViewBag.SedeID = new SelectList(db.Sedes, "SedeID", "NombreSede", suscripciones.SedeID);
            return View(suscripciones);
        }

        // GET: Suscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            if (suscripciones == null)
            {
                return HttpNotFound();
            }
            return View(suscripciones);
        }

        // POST: Suscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suscripciones suscripciones = db.Suscripciones.Find(id);
            db.Suscripciones.Remove(suscripciones);
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
