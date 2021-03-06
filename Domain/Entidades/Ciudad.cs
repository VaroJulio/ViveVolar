﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("CIUDADES")]
    public class Ciudad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [ForeignKey("Estado")]
        public int IdEstado { get; set; }

        [Required]
        [StringLength(1)]
        public string Habilitado { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual ICollection<Aeropuerto> Aeropuertos { get; set; }
    }
}
