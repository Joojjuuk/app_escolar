using AppEscolar_BackEnd.DTO.Adm;
using AppEscolar_BackEnd.DTO.Noticias;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppEscolar_BackEnd.Services.Adm
{
    public class AdmService : IAdmService
    {
        private readonly Data.DataContext _context;
        public AdmService(Data.DataContext context)
        {
            _context = context;
        }
        async Task<AdmViewDTO> IAdmService.CadastrarAdmAsync(AdmCreateDTO admCreateDTO)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == admCreateDTO.Email))
            {
                throw new Exception("Email em uso.");
            }

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(admCreateDTO.Senha);

            var novoUser = new Model.UsuarioModel
            {
                Email = admCreateDTO.Email,
                Senha = senhaHash,
                TipoUsuario = Model.ETipoUsuario.Administrador,
                Nome = admCreateDTO.Nome
            };

           
            _context.Usuarios.Add(novoUser);
            await _context.SaveChangesAsync();

            var novoAdm = new Model.AdmModel
            {
                Usuario_id = novoUser.Id,
                Nome = admCreateDTO.Nome,
                Cargo = admCreateDTO.Cargo,
                Usuario = novoUser
            };

            _context.Admins.Add(novoAdm);
            await _context.SaveChangesAsync();

            return new AdmViewDTO
            {
                Usuario_Id = novoAdm.Usuario_id,
                Nome = novoAdm.Nome,
                Email = novoUser.Email,
                Cargo = novoAdm.Cargo
            };
        }
        async Task<ViewNoticiaDTO> IAdmService.CriarNoticia(CreateNoticiaDTO noticiaDTO, Guid autorId)
        {
            var autor = await _context.Admins.FindAsync(autorId);

            if (autor == null)
            {
                throw new Exception("Autor não encontrado.");
            }

            var novaNoticia = new Model.NoticiasModel
            {
                Titulo = noticiaDTO.Titulo,
                Descricao = noticiaDTO.Descricao,
                DataPublicacao = DateTime.UtcNow,
                ImagemUrl = noticiaDTO.ImagemUrl,
                TipoNoticia = noticiaDTO.TipoNoticia,
                AutorId = autorId,
                Autor = autor.Nome 
            };

            _context.Noticias.Add(novaNoticia);
            await _context.SaveChangesAsync();

            return new ViewNoticiaDTO
            {
                Id = novaNoticia.Id,
                Titulo = novaNoticia.Titulo,
                Descricao = novaNoticia.Descricao,
                ImagemUrl = novaNoticia.ImagemUrl,
                Categoria = novaNoticia.TipoNoticia.ToString(),
                DataPublicacao = novaNoticia.DataPublicacao,
                NomeAutor = autor.Nome
            };
        }
        async Task<UpdateNoticiaDTO> IAdmService.EditarNoticiaAsync(Guid noticiaId, UpdateNoticiaDTO noticiaDto)
        {
            var noticia = await _context.Noticias.FindAsync(noticiaId);

            if (noticia == null)
            {
                throw new Exception("Notícia não encontrada.");
            }
            if (!string.IsNullOrEmpty(noticiaDto.Titulo))
            {
                noticia.Titulo = noticiaDto.Titulo;
            }
            if (!string.IsNullOrEmpty(noticiaDto.Descricao))
            {
                noticia.Descricao = noticiaDto.Descricao;
            }
            if (!string.IsNullOrEmpty(noticiaDto.ImagemUrl))
            {
                noticia.ImagemUrl = noticiaDto.ImagemUrl;
            }
            if (noticiaDto.TipoNoticia.HasValue)
            {
                noticia.TipoNoticia = noticiaDto.TipoNoticia.Value;
            }

            _context.Noticias.Update(noticia);
            await _context.SaveChangesAsync();

            return new UpdateNoticiaDTO
            {
                Titulo = noticia.Titulo,
                Descricao = noticia.Descricao,
                ImagemUrl = noticia.ImagemUrl,
                TipoNoticia = noticia.TipoNoticia
            };
        }
        async Task IAdmService.DeletarNoticiaAsync(Guid noticiaId)
        {
            var noticia = await _context.Noticias.FindAsync(noticiaId);
            if (noticia == null)
            {
                throw new Exception("Notícia não encontrada.");
            }

            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
        }
    }
}