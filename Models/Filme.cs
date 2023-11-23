using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFilmesSeries.Models
{
    [Table("Filmes")]
    public class Filme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public int Ano { get; set; }

        [MaxLength(100)]
        public string Diretor { get; set; }

        public int Duracao { get; set; }

        [MaxLength(100)]
        public string Genero { get; set; }

        [MaxLength(100)]
        public string Estudio { get; set; }

    }
}