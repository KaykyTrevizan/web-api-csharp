using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFilmesSeries.Models
{
    [Table("Series")]
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public int Ano { get; set; }

        public int Temporadas { get; set; }

        public int Episodios { get; set; }

        public bool Finalizada { get; set; }

        [MaxLength(100)]
        public string Genero { get; set; }
    }
}