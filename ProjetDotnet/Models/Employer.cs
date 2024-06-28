using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class Employer
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_emp { get; set; }

        [Required(ErrorMessage = "Le cin est obligatoire. Veuillez la saisir.")] /// champs non vide 
        public int cin_emp { get; set; }
        [Required(ErrorMessage = "le nom est obligatoire. Veuillez la saisir.")]
        public string nom_emp { get; set; }
        [Required(ErrorMessage = "Le prenom est obligatoire. Veuillez la saisir.")]
        public string prenom_emp { get; set; }
        [Required(ErrorMessage = "Date de naissance est obligatoire. Veuillez la saisir.")]
        [DataType(DataType.Date)]
        public DateTime date_naissance_emp { get; set; }
        [Required(ErrorMessage = "Date embauche est obligatoire. Veuillez la saisir.")]
        [DataType(DataType.Date)]
        public DateTime date_embauche_emp { get; set; }
        [Required(ErrorMessage = "Le sexe  est obligatoire. Veuillez la saisir.")]
        public string sexe_emp { get; set; }
        [Required(ErrorMessage = "Ville est obligatoire. Veuillez la saisir.")]
        public string ville_emp { get; set; }
        [Required(ErrorMessage = "L'adresse est obligatoire. Veuillez la saisir.")]
        public string adresse_emp { get; set; }
        [Required(ErrorMessage = "Numero de telephone est obligatoire. Veuillez la saisir.")]
        public int numtell_emp { get; set; }
        
        public int? archive_emp { get; set; } = 0;
        
        [Required(ErrorMessage = "L'adresse e-mail est obligatoire. Veuillez la saisir.")]
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide")]
        public string email_emp { get; set; }

        [Required(ErrorMessage = "Mot de passe est obligatoire. Veuillez la saisir.")]
        public string psw_emp { get; set; }

        public int? Id_post { get; set; }
        public virtual Poste? Poste { get; set; }
    }
}
