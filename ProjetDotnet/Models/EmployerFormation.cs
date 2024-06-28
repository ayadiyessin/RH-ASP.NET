using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetDotnet.Models
{
    public class EmployerFormation
    {
         // cle pr
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_empform { get; set; }
        
        [ForeignKey("employerId")]
        public int employerId { get; set; }
        public virtual Employer? Employer { get; set; }

       
        [ForeignKey("formationId")]
        public int formationId { get; set; }
        public virtual Formation? Formation { get; set; }

        [DataType(DataType.Date)]
        public DateTime? date_deb_empform { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date_fin_empform { get; set; }



    }
}
