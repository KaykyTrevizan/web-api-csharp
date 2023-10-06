using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFilmesSeries.Models
{
    [Table("Esportes")]
    public class Esportes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeEsporte { get; set; }

        [MaxLength(100)]
        public string Campeonato { get; set; }
    }
}
