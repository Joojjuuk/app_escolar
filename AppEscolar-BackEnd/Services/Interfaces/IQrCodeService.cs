using AppEscolar_BackEnd.DTO.QrCode;

namespace AppEscolar_BackEnd.Services.Interfaces
{
    public interface IQrCodeService

    {
        Task<ViewQrCodeDTO> ResgatarQrCodeAsync(ViewQrCodeDTO qrCode, bool foiUsado);


    }
}
