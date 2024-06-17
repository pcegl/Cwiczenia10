namespace Cwiczenia10.RequestModels;

public class PrescriptionRequestModel
{
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public DateTime PatientBirthdate { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentRequest> Medicaments { get; set; }
}

public class MedicamentRequest
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}