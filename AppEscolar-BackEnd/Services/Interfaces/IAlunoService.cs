using AppEscolar_BackEnd.DTO.Auth.Aluno;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<AlunoView> CadastrarAlunoAsync(AlunoCreateDTO alunoCreateDTO);
        Task<AlunoView> ObterAlunoPorIdAsync(Guid usuarioId);
    }
}