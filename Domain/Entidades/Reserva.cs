using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("RESERVAS")]
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        [Required]
        [Index("CodReservaIndex", IsUnique = true)]
        public Guid CodigoConsultaReserva { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaReserva { get; set; }

        [Required]
        public string Correo { get; set; }

        public virtual ICollection<Itinerario> Itinerarios { get; set; }
    }
}
