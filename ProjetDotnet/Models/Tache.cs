using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetDotnet.Models
{
    public class Tache
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_tache { get; set; }

        [ForeignKey("employerId")]
        public int employerId { get; set; }
        public virtual Employer? Employer { get; set; }

        [Required(ErrorMessage = "Nom tache est obligatoire. Veuillez la saisir.")] /// champs non vide 
        public string nom_tache { get; set; }

        [Required(ErrorMessage = "Date debut est obligatoire. Veuillez la saisir.")]
        [DataType(DataType.Date)]
        public DateTime date_deb_tache { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? date_fin_tache { get; set; } = null;

        public string? description_rapp { get; set; } = null;
    }
}
