using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.Model
{
    public class HistoricoDoacoesModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AlunoModel")]
        public int Aluno_Id { get; set; }
        
        [Required]
        public decimal Creditos_Ganhos { get; set; } = 0;

        [Required]
        public DateTime Data_Doacao { get; set; } = DateTime.Now;

    }
}
