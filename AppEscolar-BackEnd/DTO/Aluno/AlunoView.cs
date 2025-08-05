using AppEscolar_BackEnd.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.DTO.Auth.Aluno
{
    public class AlunoView
    {
        public Guid Usuario_Id { get; set; }
        public string Name { get; set; }
        public string Ra { get; set; }
        public string Email { get; set; }
        public float Creditos { get; set; }

        public ICollection<HistoricoDoacaoView> HistoricoView{ get; set; }
    }


    public class HistoricoDoacaoView
    {
        public decimal CreditosGanhos { get; set; }
        public DateTime DataDoacao { get; set; }
    }
}
