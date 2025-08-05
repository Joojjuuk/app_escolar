using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.Model
{
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }


        [Required]
        public ETipoUsuario TipoUsuario { get; set; }

        public AdmModel Adm { get; set; }
        public AlunoModel Aluno { get; set; }
    }

    public enum ETipoUsuario
    {
        Aluno = 1,
        Professor = 2,
        Administrador = 3
    }
}
