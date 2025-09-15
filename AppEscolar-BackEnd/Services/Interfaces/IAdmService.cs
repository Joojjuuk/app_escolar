using AppEscolar_BackEnd.DTO.Adm;
using AppEscolar_BackEnd.DTO.Noticias;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface IAdmService
    {
        Task<AdmViewDTO> CadastrarAdmAsync(AdmCreateDTO admCreateDTO);
        Task<ViewNoticiaDTO> CriarNoticia(CreateNoticiaDTO noticiaDTO, Guid autorId);
        Task<UpdateNoticiaDTO> EditarNoticiaAsync(Guid noticiaId, UpdateNoticiaDTO noticiaDto);
        Task DeletarNoticiaAsync(Guid noticiaId);
    }
}
