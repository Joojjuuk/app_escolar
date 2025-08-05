using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolar_BackEnd.Model
{
    public class AdmModel
    {
       [Key]
       [ForeignKey("UsuarioModel")]
       public Guid Usuario_id { get; set; }
       [Required]
       public string Nome { get; set; }
       public string Cargo { get;set; }


       public UsuarioModel Usuario { get; set; } 
       public ICollection<NoticiasModel> NoticiasPublicadas { get; set; } = new List<NoticiasModel>();

    }
}
