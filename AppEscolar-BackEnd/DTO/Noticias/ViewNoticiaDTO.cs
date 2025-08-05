namespace AppEscolar_BackEnd.DTO.Noticias
{
    public class ViewNoticiaDTO
    {

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string ImagemUrl { get; set; }
        public string Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string NomeAutor { get; set; }
    }
}
