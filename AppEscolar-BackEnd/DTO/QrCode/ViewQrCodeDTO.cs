namespace AppEscolar_BackEnd.DTO.QrCode
{
    public class ViewQrCodeDTO
    {
        public Guid Id { get; set; }
        public string QrCode { get; set; }
        public decimal Pontos { get; set; }
        public bool FoiUsado { get; set; }
        public DateTime DataGeracao { get; set; }

    }
}
