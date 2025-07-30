using System.ComponentModel.DataAnnotations;


namespace AppEscolar_BackEnd.Model
{
    public class NoticiasModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        [Required]
        public ETipoNoticia TipoNoticia { get; set; }
        [Required]
        public string ImagemUrl { get; set; } // URL da imagem associada à notícia
        [Required]
        public string Autor { get; set; }
       
    }
    public enum ETipoNoticia
    {
        Gerais = 1,
        Sustentabilidade = 2,
        Anuncios = 3
    }
}
