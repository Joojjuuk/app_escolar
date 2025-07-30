using Microsoft.EntityFrameworkCore;

namespace AppEscolar_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base( options ) 
        { 
        }
        public DbSet<Model.NoticiasModel> Noticias { get; set; }
        public DbSet<Model.UsuarioModel> Usuarios { get; set; }
        public DbSet<Model.AlunoModel> Alunos { get; set; }
        public DbSet<Model.AdmModel> Admins { get; set; }
        public DbSet<Model.HistoricoDoacoesModel> HistoricoDoacoes { get; set; }
    }
}
