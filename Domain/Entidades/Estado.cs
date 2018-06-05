using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("ESTADOS")]
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [ForeignKey("Pais")]
        public int IdPais { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Habilitado { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; } 
    }
}
