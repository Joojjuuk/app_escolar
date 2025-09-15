using AppEscolar_BackEnd.Model;
using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.DTO.Noticias
{
    public class UpdateNoticiaDTO
    {
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        public ETipoNoticia? TipoNoticia { get; set; }
    }
}
