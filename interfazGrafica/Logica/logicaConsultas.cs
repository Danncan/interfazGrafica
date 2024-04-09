using interfazGrafica.API_Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace interfazGrafica.Logica
{
    public class logicaConsultas
    {
        Api_Consultas.API_GestionConsultas gestorAPI = new Api_Consultas.API_GestionConsultas();

        public List<Models.Clientes> ListarClientes()
        {
            // Llamamos al método ListarClientes que devuelve una lista de SP_ListClientes_Result
            var resultadosApi = gestorAPI.ListarClientes();

            // Convertimos la lista de la API a la lista de modelos de la aplicación
            var listaClientes = resultadosApi.Select(apiCliente => new Models.Clientes
            {
                ClienteID = apiCliente.ClienteID,
                Nombre = apiCliente.Nombre,
                Apellido = apiCliente.Apellido,
                Email = apiCliente.Email,
                Telefono = apiCliente.Telefono,
                FechaRegistro = apiCliente.FechaRegistro ?? default(DateTime), // Coloca un valor predeterminado si FechaRegistro es null
                Cedula = apiCliente.Cedula,
                Activo = apiCliente.Activo ?? false // Coloca 'false' si Activo es null
            }).ToList();

            return listaClientes;
        }
        public List<Models.Sedes> ListarSedes()
        {
            // Llamamos al método ListarSedes que devuelve una lista de SP_ListSedes_Result
            var resultadosApi = gestorAPI.ListarSedes();

            // Convertimos la lista de la API a la lista de modelos de la aplicación
            var listaSedes = resultadosApi.Select(apiSede => new Models.Sedes
            {
                SedeID = apiSede.SedeID,
                NombreSede = apiSede.NombreSede,
                Direccion = apiSede.Direccion,
                Telefono = apiSede.Telefono,
                Activo = apiSede.Activo ?? false // Coloca 'false' si Activo es null
            }).ToList();

            return listaSedes;
        }

        public List<Models.Pagos> ListarPagos()
        {
            var resultadosApi = gestorAPI.ListarPagos();
            var listaPagos = resultadosApi.Select(apiPago => new Models.Pagos
            {
                PagoID = apiPago.PagoID,
                SuscripcionID = apiPago.SuscripcionID,
                FechaPago = apiPago.FechaPago ?? default(DateTime),
                Monto = apiPago.Monto,
                MetodoPago = apiPago.MetodoPago,
                Activo = apiPago.Activo ?? false
            }).ToList();
            return listaPagos;
        }

        public List<Models.Suscripciones> ListarSuscripciones()
        {
            var resultadosApi = gestorAPI.ListarSuscripciones();
            var listaSuscripciones = resultadosApi.Select(apiSuscripcion => new Models.Suscripciones
            {
                SuscripcionID = apiSuscripcion.SuscripcionID,
                ClienteID = apiSuscripcion.ClienteID,
                SedeID = apiSuscripcion.SedeID,
                FechaInicio = apiSuscripcion.FechaInicio ?? default(DateTime),
                TipoSuscripcion = apiSuscripcion.TipoSuscripcion,
                Estado = apiSuscripcion.Estado,
                Activo = apiSuscripcion.Activo ?? false,
                
            }).ToList();

            return listaSuscripciones;
        }
       


    }
}