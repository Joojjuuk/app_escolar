using AppEscolar_BackEnd.Model;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppEscolar_BackEnd.Services.Usuarios
{
    public class UserService : IUserService
    {
        private readonly Data.DataContext _context;

        public UserService(Data.DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> CadastrarUsuarioAsync(UsuarioModel usuario)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                throw new Exception("Email em uso.");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel?> ObterUsuarioPorIdAsync(Guid usuarioId)
        {
            return await _context.Usuarios.FindAsync(usuarioId);
        }

        public async Task<UsuarioModel?> ObterUsuarioPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> VerificarCredenciaisAsync(string email, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null) return false;
            return BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
        }
    }
}