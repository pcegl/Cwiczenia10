﻿// <auto-generated />
using System;
using Cwiczenia10.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cwiczenia10.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240610220223_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cwiczenia10.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdDoctor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdMedicament");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Type");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdPatient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birthdate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.HasKey("IdPatient");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdPrescription");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DueDate");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int")
                        .HasColumnName("IdDoctor");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int")
                        .HasColumnName("IdPatient");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Details");

                    b.Property<int?>("Dose")
                        .HasColumnType("int")
                        .HasColumnName("Dose");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Prescription", b =>
                {
                    b.HasOne("Cwiczenia10.Models.Doctor", "Doctor")
                        .WithMany("Prescription")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cwiczenia10.Models.Patient", "Patient")
                        .WithMany("Prescription")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("Cwiczenia10.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cwiczenia10.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Doctor", b =>
                {
                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicament");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Patient", b =>
                {
                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Cwiczenia10.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
