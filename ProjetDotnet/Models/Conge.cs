using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class Conge
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_conge { get; set; }

        [Required(ErrorMessage = "type de congé est obligatoire. Veuillez la saisir.")] /// champs non vide 
        public string type_conge { get; set; }
        [Required(ErrorMessage = "Description congé est obligatoire. Veuillez la saisir.")]
        public string description_conge { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime date_env_conge { get; set; }

        [Required(ErrorMessage = "Date debut est obligatoire. Veuillez la saisir.")]
        [DataType(DataType.Date)]
        public DateTime date_deb_conge { get; set; }
        [Required(ErrorMessage = "Date fin est obligatoire. Veuillez la saisir.")]
        [DataType(DataType.Date)]
        public DateTime date_fin_conge { get; set; }

        public int? confirmation_conge { get; set; } = 0;
        [ForeignKey("employerId")]
        public int employerId { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
