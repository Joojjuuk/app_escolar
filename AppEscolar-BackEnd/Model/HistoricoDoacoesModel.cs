using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.Model
{
    public class HistoricoDoacoesModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string CodigoUnico { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorReais { get; set; }

        public bool FoiUsado { get; set; } = false;

        public DateTime DataGeracao { get; set; } = DateTime.UtcNow;
        public DateTime? DataUso { get; set; }
        public Guid? AlunoIdUso { get; set; }
        [ForeignKey("AlunoIdUso")]
        public AlunoModel AlunoQueUsou { get; set; }
    }
}