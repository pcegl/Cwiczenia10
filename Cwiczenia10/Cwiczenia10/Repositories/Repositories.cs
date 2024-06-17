using Cwiczenia10.Contexts;
using Cwiczenia10.Models;

public class PatientRepository : IPatientRepository
{
    private readonly DatabaseContext _context;

    public PatientRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Patient GetPatientById(int id)
    {
        return _context.Patient.Find(id);
    }

    public Patient GetPatientByName(string firstName, string lastName)
    {
        return _context.Patient.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
    }

    public void AddPatient(Patient patient)
    {
        _context.Patient.Add(patient);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}

public class MedicamentRepository : IMedicamentRepository
{
    private readonly DatabaseContext _context;

    public MedicamentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Medicament GetMedicamentById(int id)
    {
        return _context.Medicament.Find(id);
    }
}

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly DatabaseContext _context;

    public PrescriptionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void AddPrescription(Prescription prescription)
    {
        _context.Prescription.Add(prescription);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}