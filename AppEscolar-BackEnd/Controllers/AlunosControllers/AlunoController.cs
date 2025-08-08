using AppEscolar_BackEnd.DTO.Auth.Aluno;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolar_BackEnd.Controllers.AlunosControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarAlunoAsync([FromBody] AlunoCreateDTO alunoCreateDTO)
        {
            try
            {
                var aluno = await _alunoService.CadastrarAlunoAsync(alunoCreateDTO);
                return CreatedAtAction(nameof(ObterAlunoPorIdAsync), new { usuarioId = aluno.Usuario_Id }, aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObterAlunoPorIdAsync(Guid usuarioId)
        {
            try
            {
                var aluno = await _alunoService.ObterAlunoPorIdAsync(usuarioId);
                if (aluno == null)
                {
                    return NotFound(new { message = "Aluno não encontrado." });
                }
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
