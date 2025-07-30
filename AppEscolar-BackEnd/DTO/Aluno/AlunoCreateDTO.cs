using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.DTO.Auth.Aluno
{
    public class AlunoCreateDTO
    {
        [Required(ErrorMessage ="O ... é obrigatorio")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo de Email é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O RA é obrigatório.")]
        [StringLength(20, ErrorMessage = "O RA deve ter no máximo 11 caracteres.")]
        public string Ra { get; set; }

    }
}
