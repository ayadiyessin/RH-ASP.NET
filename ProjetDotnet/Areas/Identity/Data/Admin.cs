using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjetDotnet.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Admin class
    public class Admin : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Nom { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Prenom { get; set; }
        [PersonalData]
        public int etat_admin { get; set; } = 1;
        [PersonalData]
        public int archive_admin { get; set; } = 0;
        [PersonalData]
        public String Role { get; set; } = "admin";
    }
}
