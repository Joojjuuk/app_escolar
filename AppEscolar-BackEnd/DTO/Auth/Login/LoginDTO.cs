using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.DTO.Auth.Login
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo de Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
