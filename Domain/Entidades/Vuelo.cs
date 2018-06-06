using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("VUELOS")]
    public class Vuelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Origen")]
        public int IdOrigen { get; set; }

        [Required]
        public DateTime HoraSalida { get; set; }

        [ForeignKey("Destino")]
        public int IdDestino { get; set; }

        [Required]
        public DateTime HoraLlegada { get; set; }

        [Required]
        public int NumPasajeros { get; set; }

        [Required]
        public decimal ValorInicialTicket { get; set; }

        [Required]
        [StringLength(1)]
        public string Habilitado { get; set; }

        public virtual OrigenDestino Origen { get; set; }

        public virtual OrigenDestino Destino { get; set; }

        public virtual ICollection<Itinerario> Itinerarios { get; set; }
    }
}
