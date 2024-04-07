using interfazGrafica.API_Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq; // No olvides incluir esta directiva


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
    }
}