using AppEscolar_BackEnd.DTO.Noticias;
using AppEscolar_BackEnd.Model;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEscolar_BackEnd.Services.Noticia
{
    public class NoticiaService : INoticiaService
    {
        private readonly Data.DataContext _context;

        public NoticiaService(Data.DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ViewNoticiaDTO>> SepararNoticiaPorTipoAsync(ETipoNoticia tipoNoticia)
        {
            var noticias = await _context.Noticias
                .Where(n => n.TipoNoticia == tipoNoticia)
                .ToListAsync();

            var resultado = new List<ViewNoticiaDTO>();

            foreach (var noticia in noticias)
            {
                string nomeAutor = null;
                if (noticia.AutorId != Guid.Empty)
                {
                    var autor = await _context.Admins.FindAsync(noticia.AutorId);
                    nomeAutor = autor?.Nome;
                }

                resultado.Add(new ViewNoticiaDTO
                {
                    Id = noticia.Id,
                    Titulo = noticia.Titulo,
                    Descricao = noticia.Descricao,
                    ImagemUrl = noticia.ImagemUrl,
                    Categoria = noticia.TipoNoticia.ToString(),
                    DataPublicacao = noticia.DataPublicacao,
                    NomeAutor = nomeAutor
                });
            }

            return resultado;
        }

        public async Task<ViewNoticiaDTO> GetNoticiaByIdAsync(Guid noticiaId)
        {
            var noticia = await _context.Noticias.FindAsync(noticiaId);

            if (noticia == null)
                throw new Exception("Notícia não encontrada.");

            string nomeAutor = null;
            if (noticia.AutorId != Guid.Empty)
            {
                var autor = await _context.Admins.FindAsync(noticia.AutorId);
                nomeAutor = autor?.Nome;
            }

            return new ViewNoticiaDTO
            {
                Id = noticia.Id,
                Titulo = noticia.Titulo,
                Descricao = noticia.Descricao,
                ImagemUrl = noticia.ImagemUrl,
                Categoria = noticia.TipoNoticia.ToString(),
                DataPublicacao = noticia.DataPublicacao,
                NomeAutor = nomeAutor
            };
        }
    }
}