using AppEscolar_BackEnd.Model;

namespace AppEscolar_BackEnd.DTO.Noticias
{
    public class CreateNoticiaDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        public ETipoNoticia TipoNoticia { get; set; }

    }
}
