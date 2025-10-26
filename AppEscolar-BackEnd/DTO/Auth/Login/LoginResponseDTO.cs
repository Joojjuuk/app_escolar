using AppEscolar_BackEnd.DTO.User;

namespace AppEscolar_BackEnd.DTO.Auth.Login
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserViewDTO Usuario { get; set; }
    }
}