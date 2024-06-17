using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;
[Table("Prescription_Medicament")]
public class Prescription_Medicament
{
    [Key,Column(Order = 0)]
    [ForeignKey("Medicament")]
    public int IdMedicament { get; set; }
    public Medicament Medicament { get; set; }
    
    [Key,Column(Order = 1)]
    [ForeignKey("Prescription")]
    public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }
    
    [Column("Dose")]
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    [Column("Details")]
    public string Details { get; set; }
}