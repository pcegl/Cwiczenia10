using Cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Prescription> Prescription { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Medicament> Medicament { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicament { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Prescription_Medicament>().HasKey(
            e => new { e.IdMedicament, e.IdPrescription });
    }
}