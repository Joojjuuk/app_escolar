using AppEscolar_BackEnd.DTO.Noticias;
using AppEscolar_BackEnd.Model;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface INoticiaService
    {
        Task<IEnumerable<ViewNoticiaDTO>> SepararNoticiaPorTipoAsync(ETipoNoticia tipoNoticia);
        Task<ViewNoticiaDTO> GetNoticiaByIdAsync(Guid noticiaId);
    }
}
