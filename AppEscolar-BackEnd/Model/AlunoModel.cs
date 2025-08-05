using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.Model
{
    public class AlunoModel
    {
        [Key]
        [ForeignKey("UsuarioModel")]
        public Guid Usuario_Id { get; set; }
        [Required]
        [StringLength(11)]
        public string Name { get; set; } 
        [Required]
        [StringLength(11)]
        public string Ra { get; set; }
        public float Creditos { get; set; } = 0;

        public UsuarioModel Usuario { get; set; }
        public ICollection<HistoricoDoacoesModel> HistoricoDoacoes { get; set; } = new List<HistoricoDoacoesModel>();

    }
}
