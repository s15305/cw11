﻿// <auto-generated />
using System;
using cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace cwiczenia11.Migrations
{
    [DbContext(typeof(CodeFirstContext))]
    [Migration("20200617231219_AddMoreData")]
    partial class AddMoreData
    {

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {

#pragma warning disable 612, 618

            modelBuilder

                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD_cwiczenia11.Models.Doctor", b =>
                {

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_PK");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {

                            IdDoctor = 1,
                            Email = "jan@kowalski.pl",
                            FirstName = "Jan",
                            LastName = "Kowalski"

                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "jan@nowak.pl",
                            FirstName = "Jan",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("cwiczenia11.Models.Medicament", b =>
                {

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Majonez",
                            Name = "Winiary",
                            Type = "Do salatek"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "aaaaa",
                            Name = "bbbbb",
                            Type = "ccccc"
                        });
                });

            modelBuilder.Entity("cwiczenia11.Models.Patient", b =>
                {

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPatient")
                        .HasName("Patient_PK");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jan",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("cwiczenia11.Models.Prescription", b =>
                {

                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_PK");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("cwiczenia11.Models.Prescription_Medicament", b =>
                {

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicaments");
                });

            modelBuilder.Entity("cwiczenia11.Models.Prescription", b =>
                {

                    b.HasOne("cwiczenia11.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("Prescription_Doctor")
                        .IsRequired();

                    b.HasOne("cwiczenia11.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("Prescription_Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("cwiczenia11.Models.Prescription_Medicament", b =>
                {

                    b.HasOne("cwiczenia11.Models.Medicament", "Medicament")
                        .WithMany("Prescription_Medicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cwiczenia11.Models.Prescription", "Prescription")
                        .WithMany("Prescription_Medicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

#pragma warning restore 612, 618
        }

    }
}
