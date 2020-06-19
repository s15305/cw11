using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia11.Models
{
    public class CodeFirstContext : DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>(entity =>
            {

                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();

                var t = new List<Patient>
                {

                    new Patient
                    {

                        IdPatient = 1,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Birthdate = new DateTime(),
                    },
                    new Patient
                    {

                        IdPatient = 2,
                        FirstName = "Jan",
                        LastName = "Nowak",
                        Birthdate = new DateTime(),

                    }

                };

                entity.HasData(t);

            });

            modelBuilder.Entity<Doctor>(entity =>
            {

                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();

                var t = new List<Doctor>
                {

                    new Doctor
                    {

                        IdDoctor = 1,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Email = "jan@kowalski.pl"
                    },
                       new Doctor
                    {

                        IdDoctor = 2,
                        FirstName = "Jan",
                        LastName = "Nowak",
                        Email = "jan@nowak.pl"

                    }

                };

                entity.HasData(t);

            });

            modelBuilder.Entity<Prescription>(entity =>
            {

                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(d => d.Patient)
                     .WithMany(d => d.Prescriptions)
                     .HasForeignKey(d => d.IdPatient)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("Prescription_Patient");

                entity.HasOne(d => d.Doctor)
                     .WithMany(d => d.Prescriptions)
                     .HasForeignKey(d => d.IdDoctor)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("Prescription_Doctor");

            });

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {

                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                entity.Property(e => e.Dose).IsRequired(false);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

            });

            modelBuilder.Entity<Medicament>(entity =>
            {

                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();

                entity.HasMany(medicament => medicament.Prescription_Medicaments)
                       .WithOne(prescMed => prescMed.Medicament)
                       .HasForeignKey(prescMed => prescMed.IdMedicament)
                       .IsRequired();

                var t = new List<Medicament>
                {

                    new Medicament
                    {

                        IdMedicament = 1,
                        Name = "Majonez",
                        Description = "Winiary",
                        Type = "Do salatek",
                    },
                       new Medicament
                    {

                        IdMedicament = 2,
                        Name = "aaaaa",
                        Description = "bbbbb",
                        Type = "ccccc",

                    },

                };

                entity.HasData(t);

            });


        }

    }

}
