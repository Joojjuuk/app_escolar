using System.ComponentModel.DataAnnotations;

namespace AppEscolar_BackEnd.DTO.QrCode
{
    public class ReadQrCodeDTO
    {
        [Required(ErrorMessage = "O código do QR Code é obrigatório.")]
        public string CodigoUnico { get; set; }
    }
}
