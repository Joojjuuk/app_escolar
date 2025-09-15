using AppEscolar_BackEnd.Model;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<UsuarioModel> CadastrarUsuarioAsync(UsuarioModel usuario);
        Task<UsuarioModel?> ObterUsuarioPorIdAsync(Guid usuarioId);
        Task<UsuarioModel?> ObterUsuarioPorEmailAsync(string email);
        Task<bool> VerificarCredenciaisAsync(string email, string senha);
    }
}