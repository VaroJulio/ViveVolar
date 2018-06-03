using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Campo Clave requerido.")]
        [Index("ClaveIndex", IsUnique = true)]
        [StringLength(12)]
        public string Clave { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
