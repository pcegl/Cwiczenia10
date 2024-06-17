using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    [Column("IdPrescription")]
    public int IdPrescription { get; set; }
    
    [Column("Date")]
    [Required]
    public DateTime Date { get; set; }
    
    [Column("DueDate")]
    [Required]
    public DateTime DueDate { get; set; }
    
    [Column("IdPatient")]
    [ForeignKey("Patient")]
    public int IdPatient { get; set; }

    public Patient Patient { get; set; }
    
    [Column("IdDoctor")]
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }

    public Doctor Doctor { get; set; }
    public List<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}