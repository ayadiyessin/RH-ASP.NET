using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Areas.Identity.Data;
using ProjetDotnet.Models;

namespace ProjetDotnet.Data
{
    public class GestionRHContext : IdentityDbContext<Admin>
    {
        public GestionRHContext(DbContextOptions<GestionRHContext> options)
            : base(options)
        {
        }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerFormation> EmployerFormations { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Poste> Postes { get; set; }

        public DbSet<Tache> Taches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployerFormation>(entity =>
            {
                entity.HasKey(e => new { e.Id_empform, e.employerId, e.formationId });
            });
            modelBuilder.Entity<Poste>(entity =>
            {
                entity.HasOne(d => d.Departement).WithMany(p => p.Postes)
                    .HasForeignKey(d => d.Id_dep)
                    .HasConstraintName("FK_dep_post");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasOne(d => d.Poste).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Id_post)
                    .HasConstraintName("FK_emp_post");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
