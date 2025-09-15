using AppEscolar_BackEnd.DTO.Adm;
using AppEscolar_BackEnd.DTO.Noticias;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolar_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdmController : ControllerBase
    {
        private readonly IAdmService _admService;

        public AdmController(IAdmService admService)
        {
            _admService = admService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarAdm([FromBody] AdmCreateDTO adm)
        {
            try
            {
                var result = await _admService.CadastrarAdmAsync(adm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("noticia")]
        public async Task<IActionResult> CriarNoticia([FromBody] CreateNoticiaDTO noticia, [FromQuery] Guid autorId)
        {
            try
            {
                var result = await _admService.CriarNoticia(noticia, autorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("noticia/{id}")]
        public async Task<IActionResult> EditarNoticia(Guid id, [FromBody] UpdateNoticiaDTO noticia)
        {
            try
            {
                var result = await _admService.EditarNoticiaAsync(id, noticia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("noticia/{id}")]
        public async Task<IActionResult> DeletarNoticia(Guid id)
        {
            try
            {
                await _admService.DeletarNoticiaAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}