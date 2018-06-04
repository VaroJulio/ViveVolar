using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("AEROPUESTOS")]
    public class Aeropuerto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        [StringLength(6)]
        public string CodigoMundial { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [ForeignKey("Ciudad")]
        public int IdCiudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }

        public virtual ICollection<OrigenDestino> OrigenDestinos { get; set; }
    }
}
