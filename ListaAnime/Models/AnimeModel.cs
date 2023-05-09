using System.ComponentModel.DataAnnotations;

namespace ListaAnime.Models
{
    public class AnimeModel
    {
        public int Id { get; set; }



        [Required]
        public string Nome { get; set; }


        [Required]
        public int Nota { get; set; }


        [Required]
        public string Descricao { get; set; }


        [Required]
        public string Temporada { get; set; }
    }
}
