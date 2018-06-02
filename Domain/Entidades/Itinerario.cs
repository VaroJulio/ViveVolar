using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("ITINERARIOS")]
    public class Itinerario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        [ForeignKey("Reserva")]
        Guid CodigoConsultaReserva { get; set; }

        [ForeignKey("Vuelo")]
        int IdVuelo { get; set; }

        [ForeignKey("Pasajero")]
        string IdentificacionPasajero { get; set; }

        public virtual Reserva Reserva { get; set; }

        public virtual Vuelo Vuelo { get; set;}

        public virtual Pasajero Pasajero { get; set; }

    }
}
