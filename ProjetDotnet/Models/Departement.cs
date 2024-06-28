using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class Departement
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_dep { get; set; }

        [Required(ErrorMessage = "id est obligatoire. Veuillez la saisir.")] /// champs non vide 
        public string? Nom_dep { get; set; }
        [Required(ErrorMessage = "Description est obligatoire. Veuillez la saisir.")]
        public string description_dep { get; set; }

        public int? archive_dep { get; set; } = 0;

        public virtual ICollection<Poste> Postes { get; set; } = new List<Poste>();
    }
}
