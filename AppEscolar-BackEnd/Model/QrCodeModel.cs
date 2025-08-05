using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.Model
{
    public class QrCodeModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string QrCode { get; set; }

        [Required]
        public string QrCodeType { get; set; }

        [Required]
        public bool FoiUsado { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        public DateTime DataUso { get; set; }


        public Guid? AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public AlunoModel? Aluno { get; set; }

    }
}
