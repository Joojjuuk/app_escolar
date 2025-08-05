using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.DTO.Adm
{
    public class AdmCreateDTO
    {
        public Guid Usuario_Id { get; set; }
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatória.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Cargo é obrigatório.")]
        public string Cargo { get; set; }



    }
}