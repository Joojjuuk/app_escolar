using AppEscolar_BackEnd.DTO.Auth.Aluno;
using AppEscolar_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using AppEscolar_BackEnd.Services.Interfaces;

namespace AppEscolar_BackEnd.Services.Aluno
{
    public class AlunoService : IAlunoService
    {
        private readonly Data.DataContext _context;

        public AlunoService(Data.DataContext context)
        {
            _context = context;
        }

        public async Task<AlunoView> CadastrarAlunoAsync(AlunoCreateDTO alunoCreateDTO)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == alunoCreateDTO.Email))
            {
                throw new Exception("Email em uso.");
            }
            if (await _context.Alunos.AnyAsync(u => u.Ra == alunoCreateDTO.Ra))
            {
                throw new Exception("RA em uso.");
            }

            // código hash para segurança senha
            string SenhaHash = BCrypt.Net.BCrypt.HashPassword(alunoCreateDTO.Senha);

            var novoUser = new UsuarioModel
            {
                Email = alunoCreateDTO.Email,
                Senha = SenhaHash,
                TipoUsuario = ETipoUsuario.Aluno
            };

            var novoAluno = new AlunoModel
            {
                Usuario_Id = novoUser.Id,
                Nome = alunoCreateDTO.Nome,
                Ra = alunoCreateDTO.Ra,
                Usuario = novoUser
            };

            _context.Usuarios.Add(novoUser);
            await _context.SaveChangesAsync();

            return new AlunoView
            {
                Usuario_Id = novoAluno.Usuario_Id,
                Name = novoAluno.Nome,
                Ra = novoAluno.Ra,
                Email = novoUser.Email,
                Creditos = novoAluno.Creditos,
                HistoricoDoacao = new List<HistoricoDoacaoView>()
            };
        }

        public async Task<AlunoView> ObterAlunoPorIdAsync(Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}