using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class Formation
    {
        [Key] // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_formation { get; set; }
        [Required(ErrorMessage = "Nom est obligatoire. Veuillez la saisir.")]
        public string nom_formation { get; set; }
        [Required(ErrorMessage = "Description est obligatoire. Veuillez la saisir.")]
        public string description_formation { get; set; }

        public int? archive_formation { get; set; } = 0;
    }
}
