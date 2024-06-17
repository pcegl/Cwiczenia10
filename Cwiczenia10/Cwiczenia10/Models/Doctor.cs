using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;
[Table("Doctor")]
public class Doctor
{
    [Key]
    [Column("IdDoctor")]
    public int IdDoctor { get; set; }

    [Column("FirstName")]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }

    public List<Prescription> Prescription { get; set; } = new List<Prescription>();
}