using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppEscolar_BackEnd.Model
{
    public class NoticiasModel
    {

        [Key]
        public Guid Id { get; set; }

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


        public Guid AutorId { get; set; }
        [ForeignKey("AutorId")]
        public AdmModel AutorAdm { get; set; } 

    }
    public enum ETipoNoticia
    {
        Gerais = 1,
        Sustentabilidade = 2,
        Anuncios = 3
    }
}
