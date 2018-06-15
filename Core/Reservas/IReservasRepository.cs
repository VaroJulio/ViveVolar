using Common.To.Reservas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Reservas
{
    public interface IReservasRepository
    {
        Task<ReservaTo> ObtenerReservaPorIdAsync(int id);
        ReservaTo ObtenerReservaPorCodigoReserva(Guid id);
        void GuardarNuevaReserva(ReservaTo vuelo);
        void ActualizarReserva(ReservaTo vuelo);
        ICollection<ItinerarioTo> ObtenerItinerariosPorIdReserva(int id);
        ICollection<ItinerarioTo> ObtenerItinerariosPorCodReserva(Guid id);
        ICollection<ItinerarioTo> ObtenerItinerarioPorIdentificacionPasajero(string id);
        void GuardarPasajeros(List<PasajeroTo> pasajeros);
        void ActualizarPasajeros(List<PasajeroTo> pasajeros);
        ICollection<PasajeroTo> ObtenerPasajerosPorIdReserva(int id);
        ICollection<PasajeroTo> ObtenerPasajerosPorCodigoReserva(Guid id);
        ICollection<PasajeroTo> ObtenerPasajerosPorVuelo(int id);
    }
}
