using AppEscolar_BackEnd.Model;
using AppEscolar_BackEnd.Services.Interfaces;
using AppEscolar_BackEnd.Services.Token;
using AppEscolar_BackEnd.DTO.Auth.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppEscolar_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;

        public UserController(IUserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.CadastrarUsuarioAsync(usuario);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao cadastrar usuário.");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            var usuario = await _userService.ObterUsuarioPorIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(new UserViewDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Cargo = usuario.TipoUsuario.ToString()
            });
        }

        [Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> ObterUsuarioPorEmail(string email)
        {
            var usuario = await _userService.ObterUsuarioPorEmailAsync(email);
            if (usuario == null) return NotFound();
            return Ok(new UserViewDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Cargo = usuario.TipoUsuario.ToString()
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var valido = await _userService.VerificarCredenciaisAsync(login.Email, login.Senha);
            if (!valido) return Unauthorized();

            var usuario = await _userService.ObterUsuarioPorEmailAsync(login.Email);
            if (usuario == null) return Unauthorized();

            var token = _tokenService.Generate(usuario);

            return Ok(new LoginResponseDTO
            {
                Token = token,
                Usuario = new UserViewDTO
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Cargo = usuario.TipoUsuario.ToString()
                }
            });
        }
    }
}