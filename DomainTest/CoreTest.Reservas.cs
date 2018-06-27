using Common.To.Maestros;
using Common.Constantes;
using Core;
using Core.Reservas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Core.Reservas.BdRepositories;
using Domain;
using Unity.Lifetime;
using Common.To.Reservas;
using Common.To.Vuelos;
using System;

namespace CoreTest
{
    #region Pruebas de Integración
    //Pruebas de integración con la base de datos
    public partial class CoreTest
    {
        [TestMethod]
        public void ObtenerReservaPorId()
        {
            ReservaTo reserva = _reservasRepo.ObtenerReservaPorIdAsync(3).Result;
            Assert.IsTrue(reserva.Correo != null);
        }

        [TestMethod]
        public void ObtenerReservaPorCodigoReserva()
        {
            ReservaTo reserva = _reservasRepo.ObtenerReservaPorCodigoReserva(new System.Guid());
            Assert.IsTrue(reserva.Correo != null);
        }

        [TestMethod]
        public void GuardarNuevaReserva()
        {
            VueloTo vuelo = new VueloTo() { IdDestino = 1, Habilitado = "S", HoraSalida = DateTime.Now, IdOrigen = 2, HoraLlegada = DateTime.Now.AddHours(2), NumPasajeros = 40, ValorInicialTicket = 50000 };
            PasajeroTo pasajero = new PasajeroTo() { Identificacion = "1065584866", FechaNacimiento = DateTime.Now.Date, Correo = "aaronsistemas@hotmail.com", NombreCompleto = "Alvaro Julio", Telefono = "3104236649" };
            ItinerarioTo itinerario = new ItinerarioTo() { IdentificacionPasajero = "1065584866", IdReserva = 1, IdVuelo = 1, ValorFinalTicket = 75000, Pasajero = pasajero, Vuelo = vuelo };
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            itinerarios.Add(itinerario);
            ReservaTo reserva = new ReservaTo() { FechaReserva = DateTime.Now, Correo = "ALVARODEV@HOTMAIL.COM", CodigoConsultaReserva = Guid.NewGuid(), Itinerarios = itinerarios };
            _reservasRepo.GuardarNuevaReserva(reserva);
        }

        [TestMethod]
        public void GuardarNuevaReservaMenosDatos()
        {
            ItinerarioTo itinerario = new ItinerarioTo() { IdentificacionPasajero = "1065623840", IdVuelo = 2, ValorFinalTicket = 100000 };
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            itinerarios.Add(itinerario);
            ReservaTo reserva = new ReservaTo() { FechaReserva = DateTime.Now, Correo = "ALVARODEV@HOTMAIL.COM", CodigoConsultaReserva = Guid.NewGuid(), Itinerarios = itinerarios };
            _reservasRepo.GuardarNuevaReserva(reserva);
        }

        [TestMethod]
        public void ActualizarReserva()
        {
            //VueloTo vuelo = new VueloTo() {Id = 1, IdDestino = 1, Habilitado = "S", HoraSalida = DateTime.Now, IdOrigen = 2, HoraLlegada = DateTime.Now.AddHours(2), NumPasajeros = 40, ValorInicialTicket = 50000 };
            //PasajeroTo pasajero2 = new PasajeroTo() { Identificacion = "1065623840", FechaNacimiento = DateTime.Now.Date, Correo = "eilenbeltran23@hotmail.com", NombreCompleto = "Eilen Beltrán", Telefono = "3102222222" };
            PasajeroTo pasajero1 = new PasajeroTo() { Identificacion = "1065584866", FechaNacimiento = DateTime.Now.Date, Correo = "aaronsistemas@hotmail.com", NombreCompleto = "Alvaro Julio", Telefono = "3256785645" };
            //ItinerarioTo itinerario2 = new ItinerarioTo() { IdentificacionPasajero = "1065623840", IdReserva = 3, IdVuelo = 1, ValorFinalTicket = 85000, Pasajero = pasajero2};
            ItinerarioTo itinerario = new ItinerarioTo() { Id = 1, IdentificacionPasajero = "1065584866", IdReserva = 3, IdVuelo = 1, ValorFinalTicket = 95000, Pasajero = pasajero1 };
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            itinerarios.Add(itinerario);
            //itinerarios.Add(itinerario2);
            ReservaTo reserva = new ReservaTo() { IdReserva = 3, FechaReserva = DateTime.Now, Correo = "ALVARODEV@HOTMAIL.COM", CodigoConsultaReserva = Guid.NewGuid(), Itinerarios = itinerarios };
            _reservasRepo.ActualizarReserva(reserva);
        }

        [TestMethod]
        public void ActualizarReservaMasDatos()
        {
            PasajeroTo pasajero2 = new PasajeroTo() { Identificacion = "1065000000", FechaNacimiento = DateTime.Now.Date, Correo = "alvarito@hotmail.com", NombreCompleto = "Alvarito Julio", Telefono = "3102222222" };
            PasajeroTo pasajero1 = new PasajeroTo() { Identificacion = "1065584866", FechaNacimiento = DateTime.Now.Date, Correo = "aaronsistemas@hotmail.com", NombreCompleto = "Alvaro Julio", Telefono = "3104236649" };
            ItinerarioTo itinerario2 = new ItinerarioTo() { Id = 1003, IdentificacionPasajero = "1065000000", IdReserva = 3, IdVuelo = 1, ValorFinalTicket = 143000, Pasajero = pasajero2 };
            ItinerarioTo itinerario1 = new ItinerarioTo() { Id = 1, IdentificacionPasajero = "1065584866", IdReserva = 3, IdVuelo = 1, ValorFinalTicket = 95000, Pasajero = pasajero1 };
            List<ItinerarioTo> itinerarios = new List<ItinerarioTo>();
            itinerarios.Add(itinerario1);
            itinerarios.Add(itinerario2);
            ReservaTo reserva = new ReservaTo() { IdReserva = 3, FechaReserva = DateTime.Now, Correo = "ajjbdeveloper@HOTMAIL.COM", CodigoConsultaReserva = Guid.NewGuid(), Itinerarios = itinerarios };
            _reservasRepo.ActualizarReserva(reserva);
        }

        [TestMethod]
        public void ObtenerItinerariosPorIdReserva()
        {
            int idREserva = 3;
            var itinerarios = _reservasRepo.ObtenerItinerariosPorIdReserva(idREserva);
            Assert.IsTrue(itinerarios != null && itinerarios.Count > 0);
        }

        [TestMethod]
        public void ObtenerItinerariosPorCodReserva()
        {
            Guid codReserva = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var itinerarios = _reservasRepo.ObtenerItinerariosPorCodReserva(codReserva);
            Assert.IsTrue(itinerarios != null && itinerarios.Count > 0);
        }

        [TestMethod]
        public void ObtenerItinerarioPorIdentificacionPasajero() {
            string idPasajero = "1065584866";
            var itinerarios = _reservasRepo.ObtenerItinerarioPorIdentificacionPasajero(idPasajero);
            Assert.IsTrue(itinerarios != null && itinerarios.Count > 0);
        }

        [TestMethod]
        public void GuardarPasajeros() {
            PasajeroTo pasajero2 = new PasajeroTo() { Identificacion = "1065000223", FechaNacimiento = DateTime.Now.Date, Correo = "1@hotmail.com", NombreCompleto = "Rick Grimes", Telefono = "3106789023" };
            PasajeroTo pasajero1 = new PasajeroTo() { Identificacion = "1065584678", FechaNacimiento = DateTime.Now.Date, Correo = "2@hotmail.com", NombreCompleto = "Jhon Berthrand", Telefono = "3145674379" };
            List<PasajeroTo> pasajeros = new List<PasajeroTo>();
            pasajeros.Add(pasajero1);
            pasajeros.Add(pasajero2);
            _reservasRepo.GuardarPasajeros(pasajeros);
        }

        [TestMethod]
        public void ActualizarPasajeros() {
            PasajeroTo pasajero2 = new PasajeroTo() { Identificacion = "1065000223", FechaNacimiento = DateTime.Now.Date, Correo = "alvaro@hotmail.com", NombreCompleto = "Rick Grimes", Telefono = "3106789023" };
            PasajeroTo pasajero1 = new PasajeroTo() { Identificacion = "1065584678", FechaNacimiento = DateTime.Now.Date, Correo = "desconocido@hotmail.com", NombreCompleto = "Jhon Berthrand", Telefono = "3145674379" };
            List<PasajeroTo> pasajeros = new List<PasajeroTo>();
            pasajeros.Add(pasajero1);
            pasajeros.Add(pasajero2);
            _reservasRepo.ActualizarPasajeros(pasajeros);
        }

        [TestMethod]
        public void ObtenerPasajerosPorIdReserva() {
            int idReserva = 3;
            var result = _reservasRepo.ObtenerPasajerosPorIdReserva(idReserva);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtenerPasajerosPorCodigoReserva() {
            Guid codReserva = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var result = _reservasRepo.ObtenerPasajerosPorCodigoReserva(codReserva);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtenerPasajerosPorVuelo() {
            int idVuelo = 1;
            var result = _reservasRepo.ObtenerPasajerosPorVuelo(idVuelo);
            Assert.IsNotNull(result);
        }
    }
    #endregion
}