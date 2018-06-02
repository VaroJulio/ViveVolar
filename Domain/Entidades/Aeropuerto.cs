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

        public string CodigoMundial { get; set; }

        [Required]
        public string Nombre { get; set; }

        [ForeignKey("Ciudad")]
        public string IdCiudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }

        public virtual OrigenDestino OrigenDestino { get; set; }
    }
}
