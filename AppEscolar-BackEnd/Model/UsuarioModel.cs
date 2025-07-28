using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.Model
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}
