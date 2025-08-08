using AppEscolar_BackEnd.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AppEscolar_BackEnd.Services.Token
{
    public class TokenService
    {
        public string Generate(UsuarioModel usuario)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateClaim(usuario),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(0.5),
            };
            var token = handler.CreateToken(tokenDescriptor);
            
            
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity CreateClaim(UsuarioModel usuario)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
            foreach (var role in usuario.TipoUsuario.ToString().Split(','))
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return ci;

        }


    }
}
