using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("PASAJEROS")]
    public class Pasajero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        string Identificacion { get; set; }

        [Required]
        string NombreCompleto { get; set; }

        [Required]
        DateTime FechaNacimiento { get; set; }

        string Correo { get; set; }

        string Telefono { get; set; }

        public virtual ICollection<Itinerario> Itinerarios { get; set; }
    }
}
