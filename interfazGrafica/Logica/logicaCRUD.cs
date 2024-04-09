using interfazGrafica.API_Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace interfazGrafica.Logica
{
    public class logicaCRUD
    {
        API_Crud.APIGestionCRUD api = new API_Crud.APIGestionCRUD();
        #region Clientes
        public void CrearCliente(Models.Clientes clietneaInsert)
        {
            API_Crud.Cliente clienteInsertado = clietneaInsert.clienteAPI();
         
            api.InsertarCliente(clienteInsertado);
        }
        public void ActualizarCliente(Models.Clientes clienteActualizar)
        {
            API_Crud.Cliente clienteActualizado = clienteActualizar.clienteAPI();
            api.ActualizarCliente(clienteActualizado);
        }
        public void EliminarCliente(int id)
        {
            api.EliminarCliente(id);
        }
        public Cliente buscarCliente (int id)
        {
            return api.ObtenerClientePorId(id);
        }
        #endregion
        #region Suscripciones
        public void CrearSuscripcion(Models.Suscripciones suscripcionInsert)
        {
            API_Crud.Suscripcione suscripcionInsertada = suscripcionInsert.suscripcionesAPI();
            api.InsertarSuscripcion(suscripcionInsertada);
        }
        public void ActualizarSuscripcion(Models.Suscripciones suscripcionActualizar)
        {
            API_Crud.Suscripcione suscripcionActualizada = suscripcionActualizar.suscripcionesAPI();
            api.ActualizarSuscripcion(suscripcionActualizada);
        }
        public void EliminarSuscripcion(int id)
        {
            api.EliminarSuscripcion(id);
        }
        public Suscripcione buscarSuscripcion(int id)
        {
            return api.ObtenerSuscripcionPorId(id);
        }
        #endregion
        #region Sedes
        public void CrearSede(Models.Sedes sedeInsert)
        {
            API_Crud.Sede sedeInsertada = sedeInsert.sedeAPI();
            api.InsertarSede(sedeInsertada);
        }
        public void ActualizarSede(Models.Sedes sedeActualizar)
        {
            API_Crud.Sede sedeActualizada = sedeActualizar.sedeAPI();
            api.ActualizarSede(sedeActualizada);
        }
        public void EliminarSede(int id)
        {
            api.EliminarSede(id);
        }
        public Sede buscarSede(int id)
        {
            return api.ObtenerSedePorId(id);
        }
        #endregion
        #region Pagos
        public void CrearPago(Models.Pagos pagoInsert)
        {
            API_Crud.Pago pagoInsertado = pagoInsert.pagosAPI();
            api.InsertarPago(pagoInsertado);
        }
        public void ActualizarPago(Models.Pagos pagoActualizar)
        {
            API_Crud.Pago pagoActualizado = pagoActualizar.pagosAPI();
            api.ActualizarPago(pagoActualizado);
        }
        public Pago buscarPago(int id)
        {
            return api.ObtenerPagoPorId(id);
        }
        public void EliminarPago(int id)
        {
            api.EliminarPago(id);
        }
        #endregion

    }
}