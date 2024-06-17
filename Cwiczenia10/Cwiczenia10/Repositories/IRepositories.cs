using Cwiczenia10.Models;

public interface IPatientRepository
{
    Patient GetPatientById(int id);
    Patient GetPatientByName(string firstName, string lastName);
    void AddPatient(Patient patient);
    void Save();
}

public interface IMedicamentRepository
{
    Medicament GetMedicamentById(int id);
}

public interface IPrescriptionRepository
{
    void AddPrescription(Prescription prescription);
    void Save();
}