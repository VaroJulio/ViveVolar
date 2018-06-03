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
        public int Id { get; set; }

        [ForeignKey("Reserva")]
        public Guid CodigoConsultaReserva { get; set; }

        [ForeignKey("Vuelo")]
        public int IdVuelo { get; set; }

        [ForeignKey("Pasajero")]
        [StringLength(15)]
        public string IdentificacionPasajero { get; set; }

        [Required]
        public decimal ValorFinalTicket { get; set; }

        public virtual Reserva Reserva { get; set; }

        public virtual Vuelo Vuelo { get; set;}

        public virtual Pasajero Pasajero { get; set; }

    }
}
