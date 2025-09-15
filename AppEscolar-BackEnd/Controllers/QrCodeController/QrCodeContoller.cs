using AppEscolar_BackEnd.DTO.QrCode;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolar_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrCodeController : ControllerBase
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpPost("resgatar")]
        public async Task<IActionResult> ResgatarQrCode([FromBody] ViewQrCodeDTO qrCode, [FromQuery] bool foiUsado)
        {
            try
            {
                var result = await _qrCodeService.ResgatarQrCodeAsync(qrCode, foiUsado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}