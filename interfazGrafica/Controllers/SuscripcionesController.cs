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

namespace interfazGrafica.Views.UISuscripciones
{
    public class SuscripcionesController : Controller
    {
        private interfazGraficaContext db = new interfazGraficaContext();
       logicaCRUD logicaCRUD = new logicaCRUD();
        logicaConsultas logicaConsultas = new logicaConsultas();

        // GET: Suscripciones
        public ActionResult Index()
        {
            
            return View(logicaConsultas.ListarSuscripcionesIndex());
        }

        // GET: Suscripciones/Details/5
        public ActionResult Details(int id)
        {
            API_Crud.Suscripcione suscripcionBuscada= logicaCRUD.buscarSuscripcion(id) ;

            Suscripciones suscripcionFinal= new Suscripciones
            {
                ClienteID = suscripcionBuscada.ClienteID,
                SedeID = suscripcionBuscada.SedeID,
                FechaInicio = suscripcionBuscada.FechaInicio,
                TipoSuscripcion = suscripcionBuscada.TipoSuscripcion,
                Estado = suscripcionBuscada.Estado,
                Activo = suscripcionBuscada.Activo,
                SuscripcionID = suscripcionBuscada.SuscripcionID
            };


            if (suscripcionFinal == null)
            {
                return HttpNotFound();
            }
            return View(suscripcionFinal);
        }

        // GET: Suscripciones/Create
        public ActionResult Create()
        {
            var clientes = logicaConsultas.ListarClientes();
            var sedes = logicaConsultas.ListarSedes();

            // Creas las SelectList usando los datos obtenidos de la API
            ViewBag.ClienteID = new SelectList(clientes, "ClienteID", "Nombre");
            ViewBag.SedeID = new SelectList(sedes, "SedeID", "NombreSede");
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
                logicaCRUD.CrearSuscripcion(suscripciones);
                return RedirectToAction("Index");
            }

            var clientes = logicaConsultas.ListarClientes();
            var sedes = logicaConsultas.ListarSedes();

            // Creas las SelectList usando los datos obtenidos de la API
            ViewBag.ClienteID = new SelectList(clientes, "ClienteID", "Nombre");
            ViewBag.SedeID = new SelectList(sedes, "SedeID", "NombreSede");

            return View(suscripciones);
        }

        // GET: Suscripciones/Edit/5
        public ActionResult Edit(int id)
        {
            API_Crud.Suscripcione suscripcionBuscada = logicaCRUD.buscarSuscripcion(id);
            Suscripciones suscripcionFinal = new Suscripciones
            {
                ClienteID = suscripcionBuscada.ClienteID,
                SedeID = suscripcionBuscada.SedeID,
                FechaInicio = suscripcionBuscada.FechaInicio,
                TipoSuscripcion = suscripcionBuscada.TipoSuscripcion,
                Estado = suscripcionBuscada.Estado,
                Activo = suscripcionBuscada.Activo,
                SuscripcionID = suscripcionBuscada.SuscripcionID
            };
            if (suscripcionFinal == null)
            {
                return HttpNotFound();
            }
            var clientes = logicaConsultas.ListarClientes();
            var sedes = logicaConsultas.ListarSedes();

            // Creas las SelectList usando los datos obtenidos de la API
            ViewBag.ClienteID = new SelectList(clientes, "ClienteID", "Nombre");
            ViewBag.SedeID = new SelectList(sedes, "SedeID", "NombreSede");

            return View(suscripcionFinal);
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
                API_Crud.Suscripcione suscripcionActualizada = suscripciones.suscripcionesAPI();
                logicaCRUD.ActualizarSuscripcion(suscripciones);
                return RedirectToAction("Index");
            }
            var clientes = logicaConsultas.ListarClientes();
            var sedes = logicaConsultas.ListarSedes();

            // Creas las SelectList usando los datos obtenidos de la API
            ViewBag.ClienteID = new SelectList(clientes, "ClienteID", "Nombre");
            ViewBag.SedeID = new SelectList(sedes, "SedeID", "NombreSede");

            return View(suscripciones);
        }

        // GET: Suscripciones/Delete/5
        public ActionResult Delete(int id)
        {
            API_Crud.Suscripcione suscripcionBuscada = logicaCRUD.buscarSuscripcion(id);
            Suscripciones suscripcionFinal = new Suscripciones
            {
                ClienteID = suscripcionBuscada.ClienteID,
                SedeID = suscripcionBuscada.SedeID,
                FechaInicio = suscripcionBuscada.FechaInicio,
                TipoSuscripcion = suscripcionBuscada.TipoSuscripcion,
                Estado = suscripcionBuscada.Estado,
                Activo = suscripcionBuscada.Activo,
                SuscripcionID = suscripcionBuscada.SuscripcionID
            };

            if (suscripcionFinal == null)
            {
                return HttpNotFound();
            }
            return View(suscripcionFinal);
        }

        // POST: Suscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           API_Crud.Suscripcione suscripcionBuscada = logicaCRUD.buscarSuscripcion(id);
            logicaCRUD.EliminarSuscripcion(suscripcionBuscada.SuscripcionID);
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
