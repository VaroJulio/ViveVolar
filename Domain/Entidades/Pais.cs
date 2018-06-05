using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("PAISES")]
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Habilitado { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
