﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Common.To.Reservas;
using Core.Reservas.BdRepositories;
using Core.Vuelos.BdRepositories;
using Domain;
using Domain.Entidades;

namespace Core.Reservas
{
    public class ReservasRepository : IReservasRepository
    {

        private ReservaRepository _reservaRepositorio { get; set; }
        private PasajeroRepository _pasajeroRepositorio { get; set; }
        private ItinerarioRepository _itinerarioRepositorio { get; set; }

        public ReservasRepository(ReservaRepository reservaRepo, PasajeroRepository pasajeroRepo, ItinerarioRepository itinerarioRepo)
        {
            _reservaRepositorio = reservaRepo;
            _pasajeroRepositorio = pasajeroRepo;
            _itinerarioRepositorio = itinerarioRepo;
        }

        public void ActualizarPasajeros(List<PasajeroTo> pasajeros)
        {
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var pasajeroRepositorio = new PasajeroRepository(Contexto);
                foreach (var pasajero in pasajeros)
                {
                    Pasajero objetoPasajeroBd = pasajeroRepositorio.ObtenerPorId(pasajero.Identificacion).Result;
                    MapearDatosActualesPasajero(objetoPasajeroBd, pasajero);
                    pasajeroRepositorio.GuardarCambios();
                }
            }
        }

        private void MapearDatosActualesPasajero(Pasajero objetoPasajeroBd, PasajeroTo pasajero)
        {
            objetoPasajeroBd.NombreCompleto = pasajero.NombreCompleto;
            objetoPasajeroBd.Telefono = pasajero.Telefono;
            objetoPasajeroBd.Correo = pasajero.Correo;
            objetoPasajeroBd.FechaNacimiento = pasajero.FechaNacimiento;
        }

        public void ActualizarReserva(ReservaTo reserva)
        {
            using (var Scope = new TransactionScope())
            {
                using (var Contexto = ViveVolarDbContext.GetDbContext())
                {
                    var reservaRepositorio = new ReservaRepository(Contexto);
                    Reserva reservaModificada = Mapper.Map<Reserva>(reserva);
                    ActualizarDatosPasajerosItinerarios(Contexto, reservaModificada);
                    Reserva objetoREservaBd = Contexto.Reservas.Find(reserva.IdReserva);
                    MapearDatosActualesReserva(objetoREservaBd, reserva);
                    reservaRepositorio.GuardarCambios();
                }
                Scope.Complete();
            }
        }

        private void ActualizarDatosPasajerosItinerarios(ViveVolarDbContext Contexto, Reserva Reserva)
        {
            foreach (var itinerario in Reserva.Itinerarios)
            {
                var pasajeroBd = Contexto.Pasajeros.Find(itinerario.IdentificacionPasajero);
                if (pasajeroBd != null)
                {
                    pasajeroBd.Correo = itinerario.Pasajero.Correo;
                    pasajeroBd.FechaNacimiento = itinerario.Pasajero.FechaNacimiento;
                    pasajeroBd.NombreCompleto = itinerario.Pasajero.NombreCompleto;
                    pasajeroBd.Telefono = itinerario.Pasajero.Telefono;
                }
                var itinerarioBd = Contexto.Itinerarios.Find(itinerario.Id);
                if (itinerarioBd != null)
                {
                    itinerarioBd.ValorFinalTicket = itinerario.ValorFinalTicket;
                }
                else
                {
                    Contexto.Itinerarios.Add(itinerario);
                }
            }
        }

        private void MapearDatosActualesReserva(Reserva objetoReservaBd, ReservaTo reserva)
        {
            Reserva reservaModificada = Mapper.Map<Reserva>(reserva);
            objetoReservaBd.FechaReserva = reservaModificada.FechaReserva;
            objetoReservaBd.Correo = reservaModificada.Correo;
        }

        public void GuardarNuevaReserva(ReservaTo reserva)
        {
            using (var Scope = new TransactionScope())
            {
                using (var Contexto = ViveVolarDbContext.GetDbContext())
                {
                    var reservaRepositorio = new ReservaRepository(Contexto);
                    Reserva objetoReserva = Mapper.Map<Reserva>(reserva);
                    reservaRepositorio.Insertar(objetoReserva);
                    reservaRepositorio.GuardarCambios();
                }
                Scope.Complete();
            }
        }

        public void GuardarPasajeros(List<PasajeroTo> pasajeros)
        {
            using (var Scope = new TransactionScope())
            {
                using (var Contexto = ViveVolarDbContext.GetDbContext())
                {
                    var pasajeroRepositorio = new PasajeroRepository(Contexto);
                    ICollection<Pasajero> objetoPasajeros = Mapper.Map<ICollection<Pasajero>>(pasajeros);
                    pasajeroRepositorio.InsertarMultiples(objetoPasajeros);
                    pasajeroRepositorio.GuardarCambios();
                }
                Scope.Complete();
            }
        }

        public ICollection<ItinerarioTo> ObtenerItinerarioPorIdentificacionPasajero(string id)
        {
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var result = itinerarioRepositorio.Filtrar(ConstruirExpresionConsultaItinerarioPorIdPasajero(id)).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
            }
            return itinerarios;
        }

        private Expression<Func<Itinerario, bool>> ConstruirExpresionConsultaItinerarioPorIdPasajero(string idPasajero)
        {
            Expression<Func<Itinerario, bool>> filtroInfo = i => i.IdentificacionPasajero == idPasajero && i.Vuelo.HoraSalida > DateTime.Now;
            return filtroInfo;
        }

        public ICollection<ItinerarioTo> ObtenerItinerariosPorCodReserva(Guid id)
        {
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var result = itinerarioRepositorio.Filtrar(ConstruirExpresionConsultaItinerarioPorCodReserva(id)).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
            }
            return itinerarios;
        }

        public ICollection<ItinerarioTo> ObtenerItinerariosPorIdReserva(int id)
        {
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var expressionFilter = ConstruirExpresionConsultaItinerarioPorIdReserva(id);
                var result = itinerarioRepositorio.Filtrar(expressionFilter).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
            }
            return itinerarios;
        }

        public ICollection<PasajeroTo> ObtenerPasajerosPorCodigoReserva(Guid id)
        {
            List<PasajeroTo> pasajeros = new List<PasajeroTo>();
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var pasajeroRepositorio = new PasajeroRepository(Contexto);
                var result = itinerarioRepositorio.Filtrar(ConstruirExpresionConsultaItinerarioPorCodReserva(id)).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
                foreach (var itinerario in itinerarios)
                {
                    pasajeros.Add(itinerario.Pasajero);
                }
            }
            return pasajeros;
        }

        private Expression<Func<Itinerario, bool>> ConstruirExpresionConsultaItinerarioPorCodReserva(Guid codReserva)
        {
            Expression<Func<Itinerario, bool>> filtroInfo = i => i.Reserva.CodigoConsultaReserva == codReserva;
            return filtroInfo;
        }

        public ICollection<PasajeroTo> ObtenerPasajerosPorIdReserva(int id)
        {
            List<PasajeroTo> pasajeros = new List<PasajeroTo>();
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var pasajeroRepositorio = new PasajeroRepository(Contexto);
                var result = itinerarioRepositorio.Filtrar(ConstruirExpresionConsultaItinerarioPorIdReserva(id)).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
                foreach (var itinerario in itinerarios)
                {
                    pasajeros.Add(itinerario.Pasajero);
                }
            }
            return pasajeros;
        }

        private Expression<Func<Itinerario, bool>> ConstruirExpresionConsultaItinerarioPorIdReserva(int idReserva)
        {
            Expression<Func<Itinerario, bool>> filtroInfo = null;
            filtroInfo = i => i.IdReserva == idReserva;
            return filtroInfo;
        }

        public ICollection<PasajeroTo> ObtenerPasajerosPorVuelo(int id)
        {
            List<PasajeroTo> pasajeros = new List<PasajeroTo>();
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var itinerarioRepositorio = new ItinerarioRepository(Contexto);
                var pasajeroRepositorio = new PasajeroRepository(Contexto);
                var result = itinerarioRepositorio.Filtrar(ConstruirExpresionConsultaItinerarioPorVuelo(id)).ToList();
                itinerarios = Mapper.Map<List<ItinerarioTo>>(result);
                foreach (var itinerario in itinerarios)
                {
                    pasajeros.Add(itinerario.Pasajero);        
                }
            }
            return pasajeros;
        }

        private Expression<Func<Itinerario, bool>> ConstruirExpresionConsultaItinerarioPorVuelo(int idVuelo)
        {
            Expression<Func<Itinerario, bool>> filtroInfo = i => i.IdVuelo == idVuelo;
            return filtroInfo;
        }

        public ReservaTo ObtenerReservaPorCodigoReserva(Guid id)
        {
            ReservaTo reserva = new ReservaTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var reservaRepositorio = new ReservaRepository(Contexto);
                var result = reservaRepositorio.Filtrar(ConstruirExpresionConsultaReservasPorCodigoReserva(id)).AsEnumerable().SingleOrDefault();
                reserva = Mapper.Map<ReservaTo>(result);
            }
            return reserva;
        }

        private Expression<Func<Reserva, bool>> ConstruirExpresionConsultaReservasPorCodigoReserva(Guid codigoReserva)
        {
            Expression<Func<Reserva, bool>> filtroInfo = r => r.CodigoConsultaReserva == codigoReserva;
            return filtroInfo;
        }

        public async Task<ReservaTo> ObtenerReservaPorIdAsync(int id)
        {
            ReservaTo reserva = new ReservaTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var reservaRepositorio = new ReservaRepository(Contexto);
                var result = await reservaRepositorio.ObtenerPorId(id.ToString());
                reserva = Mapper.Map<ReservaTo>(result);
            }
            return reserva;
        }
    }
}
