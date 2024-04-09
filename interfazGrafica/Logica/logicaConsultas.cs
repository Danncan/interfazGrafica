using interfazGrafica.API_Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;


namespace interfazGrafica.Logica
{
    public class logicaConsultas
    {
        Api_Consultas.API_GestionConsultas gestorAPI = new Api_Consultas.API_GestionConsultas();

        private ObjectCache cache = MemoryCache.Default;
        private TimeSpan cacheDuration = TimeSpan.FromMinutes(30);

        public List<Models.Clientes> ListarClientes()
        {
            string cacheKey = "clientesCacheKey";
            var clientes = cache[cacheKey] as List<Models.Clientes>;

            if (clientes == null)
            {
                clientes = gestorAPI.ListarClientes().Select(apiCliente => new Models.Clientes
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

                // Almacenar en caché
                cache.Set(cacheKey, clientes, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo cacheDuration de 30 minutos
            }

            return clientes;
        }

        public List<Models.Sedes> ListarSedes()
        {
            string cacheKey = "sedesCacheKey";
            var sedes = cache[cacheKey] as List<Models.Sedes>;

            if (sedes == null)
            {
                sedes = gestorAPI.ListarSedes().Select(apiSede => new Models.Sedes
                {
                    SedeID = apiSede.SedeID,
                    NombreSede = apiSede.NombreSede,
                    Direccion = apiSede.Direccion,
                    Telefono = apiSede.Telefono,
                    Activo = apiSede.Activo ?? false // Coloca 'false' si Activo es null
                }).ToList();

                // Almacenar en caché
                cache.Set(cacheKey, sedes, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo cacheDuration de 30 minutos
            }

            return sedes;
        }

        public List<Models.Pagos> ListarPagos()
        {
            string cacheKey = "pagosCacheKey";
            var pagos = cache[cacheKey] as List<Models.Pagos>;

            if (pagos == null)
            {
                var resultadosApi = gestorAPI.ListarPagos();
                pagos = resultadosApi.Select(apiPago => new Models.Pagos
                {
                    PagoID = apiPago.PagoID,
                    SuscripcionID = apiPago.SuscripcionID,
                    FechaPago = apiPago.FechaPago ?? default(DateTime),
                    Monto = apiPago.Monto,
                    MetodoPago = apiPago.MetodoPago,
                    Activo = apiPago.Activo ?? false
                }).ToList();

                // Almacenar en caché
                cache.Set(cacheKey, pagos, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo cacheDuration de 30 minutos
            }

            return pagos;
        }



        public List<Models.Suscripciones> ListarSuscripciones()
        {
            string cacheKey = "suscripcionesCacheKey";
            var suscripciones = cache[cacheKey] as List<Models.Suscripciones>;

            if (suscripciones == null)
            {
                var resultadosApi = gestorAPI.ListarSuscripciones();
                suscripciones = resultadosApi.Select(apiSuscripcion => new Models.Suscripciones
                {
                    SuscripcionID = apiSuscripcion.SuscripcionID,
                    ClienteID = apiSuscripcion.ClienteID,
                    SedeID = apiSuscripcion.SedeID,
                    FechaInicio = apiSuscripcion.FechaInicio ?? default(DateTime),
                    TipoSuscripcion = apiSuscripcion.TipoSuscripcion,
                    Estado = apiSuscripcion.Estado,
                    Activo = apiSuscripcion.Activo ?? false
                }).ToList();

                // Almacenar en caché
                cache.Set(cacheKey, suscripciones, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo cacheDuration de 30 minutos
            }

            return suscripciones;
        }

        public List<Models.SuscripcionesIndex> ListarSuscripcionesIndex()
        {
            string cacheKey = "suscripcionesIndexCacheKey";
            var suscripcionesIndex = cache[cacheKey] as List<Models.SuscripcionesIndex>;

            if (suscripcionesIndex == null)
            {
                var resultadosApi = gestorAPI.suscripcionesConNombresFinales();
                suscripcionesIndex = resultadosApi.Select(apiSuscripcion => new Models.SuscripcionesIndex
                {
                    SuscripcionID = apiSuscripcion.SuscripcionID,
                    ClienteID = apiSuscripcion.ClienteID,
                    SedeID = apiSuscripcion.SedeID,
                    Nombre = apiSuscripcion.Nombre,
                    NombreSede = apiSuscripcion.NombreSede,
                    FechaInicio = apiSuscripcion.FechaInicio ?? default(DateTime),
                    TipoSuscripcion = apiSuscripcion.TipoSuscripcion,
                    Estado = apiSuscripcion.Estado,
                    Activo = apiSuscripcion.Activo ?? false,
                }).ToList();

                // Almacenar en caché
                cache.Set(cacheKey, suscripcionesIndex, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo cacheDuration de 30 minutos
            }

            return suscripcionesIndex;
        }


        private void ActualizarCache<T>(string cacheKey, Func<List<T>> obtenerDatosDesdeApi)
        {
            var datosActualizados = obtenerDatosDesdeApi();
            cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo el mismo cacheDuration
        }

        public void ActualizarCacheSedes()
        {
            ActualizarCache("sedesCacheKey", () => gestorAPI.ListarSedes().Select(apiSede => new Models.Sedes
            {
                SedeID = apiSede.SedeID,
                NombreSede = apiSede.NombreSede,
                Direccion = apiSede.Direccion,
                Telefono = apiSede.Telefono,
                Activo = apiSede.Activo ?? false
            }).ToList());
        }

        public void ActualizarCacheClientes()
        {
            ActualizarCache("clientesCacheKey", () => gestorAPI.ListarClientes().Select(apiCliente => new Models.Clientes
            {
                ClienteID = apiCliente.ClienteID,
                Nombre = apiCliente.Nombre,
                Apellido = apiCliente.Apellido,
                Email = apiCliente.Email,
                Telefono = apiCliente.Telefono,
                FechaRegistro = apiCliente.FechaRegistro ?? default(DateTime),
                Cedula = apiCliente.Cedula,
                Activo = apiCliente.Activo ?? false
            }).ToList());
        }


        public void ActualizarCachePagos()
        {
            ActualizarCache("pagosCacheKey", () => gestorAPI.ListarPagos().Select(apiPago => new Models.Pagos
            {
                PagoID = apiPago.PagoID,
                SuscripcionID = apiPago.SuscripcionID,
                FechaPago = apiPago.FechaPago ?? default(DateTime),
                Monto = apiPago.Monto,
                MetodoPago = apiPago.MetodoPago,
                Activo = apiPago.Activo ?? false
            }).ToList());
        }


        public void ActualizarCacheSuscripciones()
        {
            ActualizarCache("suscripcionesCacheKey", () => gestorAPI.ListarSuscripciones().Select(apiSuscripcion => new Models.Suscripciones
            {
                SuscripcionID = apiSuscripcion.SuscripcionID,
                ClienteID = apiSuscripcion.ClienteID,
                SedeID = apiSuscripcion.SedeID,
                FechaInicio = apiSuscripcion.FechaInicio ?? default(DateTime),
                TipoSuscripcion = apiSuscripcion.TipoSuscripcion,
                Estado = apiSuscripcion.Estado,
                Activo = apiSuscripcion.Activo ?? false
            }).ToList());
        }

        public void ActualizarCacheSuscripcionesIndex()
        {
            ActualizarCache("suscripcionesIndexCacheKey", () => gestorAPI.suscripcionesConNombresFinales().Select(apiSuscripcion => new Models.SuscripcionesIndex
            {
                SuscripcionID = apiSuscripcion.SuscripcionID,
                ClienteID = apiSuscripcion.ClienteID,
                SedeID = apiSuscripcion.SedeID,
                Nombre = apiSuscripcion.Nombre,
                NombreSede = apiSuscripcion.NombreSede,
                FechaInicio = apiSuscripcion.FechaInicio ?? default(DateTime),
                TipoSuscripcion = apiSuscripcion.TipoSuscripcion,
                Estado = apiSuscripcion.Estado,
                Activo = apiSuscripcion.Activo ?? false,
            }).ToList());
        }


    }
}