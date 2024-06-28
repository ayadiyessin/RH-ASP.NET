using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class Poste
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_post { get; set; }

        [Required(ErrorMessage = "Nom poste est obligatoire. Veuillez la saisir.")] /// champs non vide 
        public string Nom_post { get; set; }
        [Required(ErrorMessage = "Description est obligatoire. Veuillez la saisir.")]
        public string description_post { get; set; }
        [Required(ErrorMessage = "Salaire est obligatoire. Veuillez la saisir.")]
        [Range(100, 9999)]
        public decimal salaire_post { get; set; }
        
        public int? Id_dep { get; set; }
        public virtual Departement? Departement { get; set; }

        public int? archive_poste { get; set; } = 0;

        public virtual ICollection<Employer> Employees { get; set; } = new List<Employer>();

    }
}
