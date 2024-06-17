using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;
[Table("Medicament")]
public class Medicament
{
    [Key]
    [Column("IdMedicament")]
    public int IdMedicament { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("Description")]
    [MaxLength(100)]
    public string Description { get; set; }
    
    [Column("Type")]
    [MaxLength(100)]
    public string Type { get; set; }

    public List<Prescription_Medicament> PrescriptionMedicament { get; set; }
}