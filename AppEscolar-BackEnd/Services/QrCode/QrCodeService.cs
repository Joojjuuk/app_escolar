using AppEscolar_BackEnd.Services.Interfaces;
using AppEscolar_BackEnd.Data;
using AppEscolar_BackEnd.DTO.QrCode;

namespace AppEscolar_BackEnd.Services.QrCode
{
    public class QrCodeService : IQrCodeService
    {
        private readonly DataContext _context;


        public QrCodeService(DataContext context)
        {
            _context = context;
        }

        async Task<ViewQrCodeDTO> IQrCodeService.ResgatarQrCodeAsync(ViewQrCodeDTO qrCode, bool foiUsado)
        {
            var Codigo = await _context.QrCode.FindAsync(qrCode.Id);
            if (Codigo == null)
            {
                throw new Exception("QrCode não encontrado.");
            }

            if (Codigo.FoiUsado = true)
            {
                throw new Exception("QrCode já foi usado.");
            }

            Codigo.FoiUsado = foiUsado;
            Codigo.DataUso = DateTime.Now;
            _context.QrCode.Update(Codigo);
            await _context.SaveChangesAsync();

            return new ViewQrCodeDTO
            {
                Id = Codigo.Id,
                QrCode = Codigo.QrCode,
                Pontos = Codigo.Pontos,
                FoiUsado = Codigo.FoiUsado,
                DataGeracao = Codigo.DataCriacao
            };

        }
    }
}
