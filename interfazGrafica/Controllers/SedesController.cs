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
using interfazGrafica.Logica;

namespace interfazGrafica.Views.UISedes
{
    public class SedesController : Controller
    {
        private interfazGraficaContext db = new interfazGraficaContext();
        logicaCRUD logicaCRUD = new logicaCRUD();
        logicaConsultas logicaConsultas = new logicaConsultas();
        // GET: Sedes
        public ActionResult Index()
        {
            return View(logicaConsultas.ListarSedes());
        }

        // GET: Sedes/Details/5
        public ActionResult Details(int id)
        {
            API_Crud.Sede sedeBuscada = logicaCRUD.buscarSede(id);
            Sedes sedeFinal = new Sedes
            {
                NombreSede = sedeBuscada.NombreSede,
                Direccion = sedeBuscada.Direccion,
                Telefono = sedeBuscada.Telefono,
                Activo = sedeBuscada.Activo,
                SedeID = sedeBuscada.SedeID
            };

            
            if (sedeFinal == null)
            {
                return HttpNotFound();
            }
            return View(sedeFinal);
        }

        // GET: Sedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SedeID,NombreSede,Direccion,Telefono,Activo")] Sedes sedes)
        {
            if (ModelState.IsValid)
            {
               logicaCRUD.CrearSede(sedes);
                logicaConsultas.ActualizarCacheSedes();
                return RedirectToAction("Index");
            }

            return View(sedes);
        }

        // GET: Sedes/Edit/5
        public ActionResult Edit(int id)
        {
            API_Crud.Sede sedeBuscada = logicaCRUD.buscarSede(id);
            Sedes sedeFinal = new Sedes
            {
                NombreSede = sedeBuscada.NombreSede,
                Direccion = sedeBuscada.Direccion,
                Telefono = sedeBuscada.Telefono,
                Activo = sedeBuscada.Activo,
                SedeID = sedeBuscada.SedeID
            };
            
            
         
            if (sedeFinal == null)
            {
                return HttpNotFound();
            }
            return View(sedeFinal);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SedeID,NombreSede,Direccion,Telefono,Activo")] Sedes sedes)
        {
            if (ModelState.IsValid)
            {
                logicaCRUD.ActualizarSede(sedes);
                logicaConsultas.ActualizarCacheSedes();
                return RedirectToAction("Index");
            }
            return View(sedes);
        }

        // GET: Sedes/Delete/5
        public ActionResult Delete(int id)
        {
           
            API_Crud.Sede sedeBuscada = logicaCRUD.buscarSede(id);
            Sedes sedeFinal = new Sedes
            {
                NombreSede = sedeBuscada.NombreSede,
                Direccion = sedeBuscada.Direccion,
                Telefono = sedeBuscada.Telefono,
                Activo = sedeBuscada.Activo,
                SedeID = sedeBuscada.SedeID
            };
            
            if (sedeFinal == null)
            {
                return HttpNotFound();
            }
            return View(sedeFinal);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            API_Crud.Sede sedeBuscada = logicaCRUD.buscarSede(id);
            logicaCRUD.EliminarSede(id);
            logicaConsultas.ActualizarCacheSedes();
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
