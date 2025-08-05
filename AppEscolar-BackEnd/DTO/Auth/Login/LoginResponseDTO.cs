namespace AppEscolar_BackEnd.DTO.Auth.Login
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserViewDTO Usuario { get; set; }
    }
    public class UserViewDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
    }

}