using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    [Column("IdPatient")]
    public int IdPatient { get; set; }
    
    [Column("FirstName")]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Column("Birthdate")]
    [Required]
    public DateTime Birthdate { get; set; }

    public List<Prescription> Prescription { get; set; } = new List<Prescription>();
}