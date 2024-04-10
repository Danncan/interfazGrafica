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
using PagedList;

namespace interfazGrafica.Views.UIClientes
{
    public class ClientesController : Controller
    {
        logicaCRUD logicaCRUD = new logicaCRUD();
        logicaConsultas logicaConsultas = new logicaConsultas();

        // GET: Clientes
        public ActionResult Index(int? page)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);

            var clientes = logicaConsultas.ListarClientes().ToPagedList(pageNumber, pageSize);
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            
           API_Crud.Cliente clienteBuscado= logicaCRUD.buscarCliente(id) ;
            Clientes clienteFinal = new Clientes { 
                Nombre=clienteBuscado.Nombre,
                Apellido=clienteBuscado.Apellido,
                Email=clienteBuscado.Email,
                Telefono=clienteBuscado.Telefono,
                Activo=clienteBuscado.Activo,
                FechaRegistro=clienteBuscado.FechaRegistro,
                Cedula=clienteBuscado.Cedula,
                ClienteID=clienteBuscado.ClienteID
                };
            if (clienteBuscado == null)
            {
                return HttpNotFound();
            }
            return View(clienteFinal);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nombre,Apellido,Email,Telefono,FechaRegistro,Cedula,Activo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                logicaCRUD.CrearCliente(clientes);
                logicaConsultas.ActualizarCacheClientes();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            API_Crud.Cliente clienteBuscado = logicaCRUD.buscarCliente(id);
            Clientes clienteFinal = new Clientes
            {
                Nombre = clienteBuscado.Nombre,
                Apellido = clienteBuscado.Apellido,
                Email = clienteBuscado.Email,
                Telefono = clienteBuscado.Telefono,
                Activo = clienteBuscado.Activo,
                FechaRegistro = clienteBuscado.FechaRegistro,
                Cedula = clienteBuscado.Cedula,
                ClienteID = clienteBuscado.ClienteID
            };
            if (clienteBuscado == null)
            {
                return HttpNotFound();
            }
            return View(clienteFinal);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nombre,Apellido,Email,Telefono,FechaRegistro,Cedula,Activo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {

                logicaCRUD.ActualizarCliente(clientes);
                logicaConsultas.ActualizarCacheClientes();


                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            API_Crud.Cliente clienteBuscado = logicaCRUD.buscarCliente(id);
            Clientes clienteFinal = new Clientes
            {
                Nombre = clienteBuscado.Nombre,
                Apellido = clienteBuscado.Apellido,
                Email = clienteBuscado.Email,
                Telefono = clienteBuscado.Telefono,
                Activo = clienteBuscado.Activo,
                FechaRegistro = clienteBuscado.FechaRegistro,
                Cedula = clienteBuscado.Cedula,
                ClienteID = clienteBuscado.ClienteID
            };


            if (clienteFinal == null)
            {
                return HttpNotFound();
            }
            return View(clienteFinal);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            API_Crud.Cliente clienteBuscado = logicaCRUD.buscarCliente(id);           
            logicaCRUD.EliminarCliente(clienteBuscado.ClienteID);
            logicaConsultas.ActualizarCacheClientes();

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
