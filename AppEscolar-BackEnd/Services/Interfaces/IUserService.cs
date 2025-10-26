using AppEscolar_BackEnd.Model;
using AppEscolar_BackEnd.DTO.User;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewDTO> CadastrarUsuarioAsync(UserCreateDTO usuarioDTO);
        Task<UsuarioModel?> ObterUsuarioPorIdAsync(Guid usuarioId);
        Task<UsuarioModel?> ObterUsuarioPorEmailAsync(string email);
        Task<bool> VerificarCredenciaisAsync(string email, string senha);
    }
}