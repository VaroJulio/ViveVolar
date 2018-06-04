using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("ORIGENESDESTINOS")]
    public class OrigenDestino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Aeropuerto")]
        public int IdAeropuerto { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public bool EsOrigen { get; set; }

        [Required]
        public bool EsDestino { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Habilitado { get; set; }

        public virtual Aeropuerto Aeropuerto { get; set; }

        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
